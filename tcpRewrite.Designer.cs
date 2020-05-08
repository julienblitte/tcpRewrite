namespace tcpRwrite
{
    partial class tcpRewrite
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tcpRewrite));
            this.destPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.destIP = new System.Windows.Forms.TextBox();
            this.toggle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.fromPort = new System.Windows.Forms.NumericUpDown();
            this.replacementsGrid = new System.Windows.Forms.DataGridView();
            this.Search = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Replace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.way = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.fromIP = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.destPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.replacementsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // destPort
            // 
            this.destPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.destPort.Location = new System.Drawing.Point(476, 57);
            this.destPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.destPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.destPort.Name = "destPort";
            this.destPort.Size = new System.Drawing.Size(76, 20);
            this.destPort.TabIndex = 4;
            this.destPort.Value = new decimal(new int[] {
            6554,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Forward to";
            // 
            // destIP
            // 
            this.destIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destIP.Location = new System.Drawing.Point(76, 57);
            this.destIP.Name = "destIP";
            this.destIP.Size = new System.Drawing.Size(394, 20);
            this.destIP.TabIndex = 3;
            this.destIP.Text = "127.0.0.1";
            // 
            // toggle
            // 
            this.toggle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toggle.Location = new System.Drawing.Point(216, 381);
            this.toggle.Name = "toggle";
            this.toggle.Size = new System.Drawing.Size(145, 39);
            this.toggle.TabIndex = 6;
            this.toggle.Text = "Start";
            this.toggle.UseVisualStyleBackColor = true;
            this.toggle.Click += new System.EventHandler(this.toggle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Listen from";
            // 
            // fromPort
            // 
            this.fromPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromPort.Location = new System.Drawing.Point(476, 22);
            this.fromPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.fromPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fromPort.Name = "fromPort";
            this.fromPort.Size = new System.Drawing.Size(76, 20);
            this.fromPort.TabIndex = 2;
            this.fromPort.Value = new decimal(new int[] {
            554,
            0,
            0,
            0});
            // 
            // replacementsGrid
            // 
            this.replacementsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replacementsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.replacementsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.replacementsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Search,
            this.Replace,
            this.way});
            this.replacementsGrid.Location = new System.Drawing.Point(15, 116);
            this.replacementsGrid.Name = "replacementsGrid";
            this.replacementsGrid.Size = new System.Drawing.Size(537, 248);
            this.replacementsGrid.TabIndex = 5;
            // 
            // Search
            // 
            this.Search.HeaderText = "Regex";
            this.Search.Name = "Search";
            // 
            // Replace
            // 
            this.Replace.HeaderText = "Replace";
            this.Replace.Name = "Replace";
            // 
            // way
            // 
            this.way.HeaderText = "Way";
            this.way.Items.AddRange(new object[] {
            "Both",
            "Forward",
            "Backward",
            "None"});
            this.way.Name = "way";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Replace text";
            // 
            // fromIP
            // 
            this.fromIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fromIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromIP.FormattingEnabled = true;
            this.fromIP.Location = new System.Drawing.Point(76, 21);
            this.fromIP.Name = "fromIP";
            this.fromIP.Size = new System.Drawing.Size(394, 21);
            this.fromIP.TabIndex = 14;
            // 
            // tcpRewrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 436);
            this.Controls.Add(this.fromIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.replacementsGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fromPort);
            this.Controls.Add(this.toggle);
            this.Controls.Add(this.destIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.destPort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "tcpRewrite";
            this.Text = "TCP rewrite";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.tcpRewrite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.destPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.replacementsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown destPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox destIP;
        private System.Windows.Forms.Button toggle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown fromPort;
        private System.Windows.Forms.DataGridView replacementsGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn Replace;
        private System.Windows.Forms.DataGridViewComboBoxColumn way;
        private System.Windows.Forms.ComboBox fromIP;
    }
}

