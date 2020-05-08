using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tcpRwrite
{
    public partial class tcpRewrite : Form
    {
        private bool status;

        private TcpListener localServer; // will listen
        private TcpClient distantServer;   // will connect to real RTSP server

        private TcpClient localServerClient;  // client connected to middle server

        private NetworkStream localServerClientStream, distantServerStream;

        private Thread mainThread;

        private byte[] fromLocalServerClient, fromDistantServer;


        private struct replacementEntry
        {
            public Regex regex;
            public string replacement;
            public bool forward;
            public bool backward;
        }

        private replacementEntry[] replacements;

        public tcpRewrite()
        {
            InitializeComponent();
            status = false;
        }

        private void mainThreadProc(object sender)
        {
            //Thread clientToServerThread, serverToClientThread;

            fromLocalServerClient = new byte[1500];
            fromDistantServer = new byte[1500];

            while (status)
            {
                try
                {
                    localServerClient = localServer.AcceptTcpClient();
                }
                catch
                {
                    if (!status)
                        break;
                }
                Trace.WriteLine(String.Format("New client connected: {0}", localServerClient.Client.RemoteEndPoint.ToString()));
                localServerClientStream = localServerClient.GetStream();

                try
                {
                    distantServer = new TcpClient(destIP.Text, (UInt16)destPort.Value);
                }
                catch
                {
                    Trace.WriteLine(String.Format("Error: Unable to establish connection to: {0}:{1}", destIP.Text, (UInt16)destPort.Value));
                    break;
                }
                Trace.WriteLine(String.Format("Connected to: {0}", distantServer.Client.RemoteEndPoint.ToString()));
                distantServerStream = distantServer.GetStream();

                localServerClientStream.BeginRead(fromLocalServerClient, 0, fromLocalServerClient.Length, localServerClientStreamRead, null);
                distantServerStream.BeginRead(fromDistantServer, 0, fromDistantServer.Length, distantServerStreamRead, null);
            }
            ((tcpRewrite)sender).stop();
        }

        string processReplacement(string text, bool forward, bool backward)
        {
            for (int i = 0; i < replacements.Length; i++)
            {
                if ((replacements[i].forward && forward)
                || (replacements[i].backward && backward))
                {
                    text = replacements[i].regex.Replace(text, replacements[i].replacement);
                }
            }
            return text;
        }

        void localServerClientStreamRead(IAsyncResult ar)
        {
            int read;
            string text;
            byte[] output;

            if (!status)
                return;

            try
            {
                read = localServerClientStream.EndRead(ar);
                text = Encoding.UTF8.GetString(fromLocalServerClient, 0, read);
                text = processReplacement(text, true, false);
                output = Encoding.UTF8.GetBytes(text);

                if (output.Length != 0)
                {
                    distantServerStream.Write(output, 0, output.Length);
                    Trace.WriteLine(String.Format("{0}({4} bytes) {1}\r\n{2}\r\n{3}\r\n", "client", "{", text, "}", text.Length));
                }

                localServerClientStream.BeginRead(fromLocalServerClient, 0, fromLocalServerClient.Length, localServerClientStreamRead, null);
            }
            catch
            {
                Trace.WriteLine("Connexion closed.");
                stop();
                return;
            }
        }

        void distantServerStreamRead(IAsyncResult ar)
        {
            int read;
            string text;
            byte[] output;

            if (!status)
                return;

            try
            {
                read = distantServerStream.EndRead(ar);
                text = Encoding.UTF8.GetString(fromDistantServer, 0, read);
                text = processReplacement(text, false, true);
                output = Encoding.UTF8.GetBytes(text);

                if (output.Length != 0)
                {
                    localServerClientStream.Write(output, 0, output.Length);
                    Trace.WriteLine(String.Format("{0}({4} bytes) {1}\r\n{2}\r\n{3}\r\n", "server", "{", text, "}", text.Length));
                }

                distantServerStream.BeginRead(fromDistantServer, 0, fromDistantServer.Length, distantServerStreamRead, null);
            }
            catch
            {
                Trace.WriteLine("Connexion closed.");
                stop();
                return;
            }
        }

        private void stop()
        {
            status = false;

            if (distantServer != null)
            {
                distantServer.Close();
            }

            if (localServerClient != null)
            {
                localServerClient.Close();
            }

            if (localServer != null)
            {
                localServer.Stop();
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { updateGUI(); }));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop();
        }

        private void loadReplacements()
        {
            List<replacementEntry> entries;

            entries = new List<replacementEntry>();

            foreach (DataGridViewRow row in replacementsGrid.Rows)
            {
                replacementEntry entry;

                entry = new replacementEntry();

                if (row.Cells[0].Value == null)
                    continue;

                try
                {
                    entry.regex = new Regex(row.Cells[0].Value.ToString());
                }
                catch
                {
                    continue;
                }

                entry.replacement = row.Cells[1].Value.ToString();
                switch (row.Cells[2].Value.ToString())
                {
                    case "Forward":
                        entry.forward = true;
                        entry.backward = false;
                        break;
                    case "Backward":
                        entry.backward = true;
                        entry.forward = false;
                        break;
                    case "Both":
                        entry.forward = true;
                        entry.backward = true;
                        break;
                    default:
                    case "None":
                        entry.forward = false;
                        entry.backward = false;
                        break;
                }
                entries.Add(entry);
            }

            replacements = entries.ToArray();
        }

        private void start()
        {
            status = true;
            updateGUI();

            loadReplacements();

            try
            {
                localServer = new TcpListener(IPAddress.Parse(fromIP.Text), (int)fromPort.Value);
                localServer.Start();

                mainThread = new Thread(mainThreadProc);
                mainThread.Start(this);
            }
            catch
            {
                MessageBox.Show(String.Format("Unable to listen on {0}:{1}!", fromIP.Text, fromPort.Value), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stop();
            }
        }

        protected NetworkInterface[] listActiveInterface()
        {
            var interfaceList =
                from iface in NetworkInterface.GetAllNetworkInterfaces()
                where iface.OperationalStatus == OperationalStatus.Up
                select iface;

            return interfaceList.Cast<NetworkInterface>().ToArray();
        }

        protected IPAddress[] listInterfaceAddresses(NetworkInterface iface, AddressFamily adressType)
        {
            var addressList =
                from addr in iface.GetIPProperties().UnicastAddresses
                where (addr.Address.AddressFamily == adressType)
                select addr.Address;

            return addressList.Cast<IPAddress>().ToArray();
        }


        private void tcpRewrite_Load(object sender, EventArgs e)
        {
            fromIP.Items.Add("0.0.0.0");

            var nicList = listActiveInterface();
            foreach(var nic in nicList)
            {
                var addrList = listInterfaceAddresses(nic, AddressFamily.InterNetwork);
                foreach(var addr in addrList)
                {
                    fromIP.Items.Add(addr.ToString());
                }
            }

            fromIP.SelectedIndex = 0;
        }

        private void toggle_Click(object sender, EventArgs e)
        {
            if (status)
            {
                stop();
            }
            else
            {
                start();
            }
        }

        private void updateGUI()
        {
            toggle.Text = (status ? "Stop" : "Start");

            replacementsGrid.ReadOnly = status;
        }
    }
}
