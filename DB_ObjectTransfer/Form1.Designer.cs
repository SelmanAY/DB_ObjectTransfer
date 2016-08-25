namespace DB_ObjectTransfer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.fastDataListView1 = new BrightIdeasSoftware.FastDataListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miClear = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadCsv = new System.Windows.Forms.Button();
            this.barRenderer1 = new BrightIdeasSoftware.BarRenderer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.btnSrcConnect = new System.Windows.Forms.Button();
            this.cbxSrcDatabases = new System.Windows.Forms.ComboBox();
            this.cbxSrcAuth = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDstConnect = new System.Windows.Forms.Button();
            this.cbxDstDatabases = new System.Windows.Forms.ComboBox();
            this.cbxDstAuth = new System.Windows.Forms.ComboBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.pbTotal = new System.Windows.Forms.ProgressBar();
            this.btnLoadFromDb = new System.Windows.Forms.Button();
            this.miClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.miClearSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.miClearSucceded = new System.Windows.Forms.ToolStripMenuItem();
            this.miClearFailed = new System.Windows.Forms.ToolStripMenuItem();
            this.imAutoScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSrcPass = new CueTextBox();
            this.txtSrcLogin = new CueTextBox();
            this.txtSrcServer = new CueTextBox();
            this.txtDstPass = new CueTextBox();
            this.txtDstLogin = new CueTextBox();
            this.txtDstServer = new CueTextBox();
            this.reseedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miReseedAll = new System.Windows.Forms.ToolStripMenuItem();
            this.miUnreseedAll = new System.Windows.Forms.ToolStripMenuItem();
            this.miReseedSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.miUnreseedSelected = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpSource.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fastDataListView1
            // 
            this.fastDataListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastDataListView1.CellEditUseWholeCell = false;
            this.tableLayoutPanel1.SetColumnSpan(this.fastDataListView1, 2);
            this.fastDataListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.fastDataListView1.DataMember = null;
            this.fastDataListView1.DataSource = null;
            this.fastDataListView1.FullRowSelect = true;
            this.fastDataListView1.GridLines = true;
            this.fastDataListView1.Location = new System.Drawing.Point(3, 223);
            this.fastDataListView1.Name = "fastDataListView1";
            this.fastDataListView1.ShowGroups = false;
            this.fastDataListView1.Size = new System.Drawing.Size(406, 203);
            this.fastDataListView1.TabIndex = 0;
            this.fastDataListView1.UseCompatibleStateImageBehavior = false;
            this.fastDataListView1.View = System.Windows.Forms.View.Details;
            this.fastDataListView1.VirtualMode = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miClear,
            this.imAutoScroll,
            this.reseedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // miClear
            // 
            this.miClear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miClearAll,
            this.miClearSelected,
            this.miClearSucceded,
            this.miClearFailed});
            this.miClear.Name = "miClear";
            this.miClear.Size = new System.Drawing.Size(152, 22);
            this.miClear.Text = "Clear";
            // 
            // btnLoadCsv
            // 
            this.btnLoadCsv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadCsv.Location = new System.Drawing.Point(209, 193);
            this.btnLoadCsv.Name = "btnLoadCsv";
            this.btnLoadCsv.Size = new System.Drawing.Size(200, 24);
            this.btnLoadCsv.TabIndex = 1;
            this.btnLoadCsv.Text = "Load CSV File";
            this.btnLoadCsv.UseVisualStyleBackColor = true;
            this.btnLoadCsv.Click += new System.EventHandler(this.btnLoadCsv_Click);
            // 
            // barRenderer1
            // 
            this.barRenderer1.CanWrap = true;
            this.barRenderer1.CellVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.barRenderer1.MaximumWidth = 10000;
            this.barRenderer1.UseGdiTextRendering = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnLoadCsv, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.fastDataListView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grpSource, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTransfer, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pbTotal, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadFromDb, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(412, 469);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.btnSrcConnect);
            this.grpSource.Controls.Add(this.cbxSrcDatabases);
            this.grpSource.Controls.Add(this.cbxSrcAuth);
            this.grpSource.Controls.Add(this.txtSrcPass);
            this.grpSource.Controls.Add(this.txtSrcLogin);
            this.grpSource.Controls.Add(this.txtSrcServer);
            this.grpSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSource.Location = new System.Drawing.Point(3, 3);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(200, 184);
            this.grpSource.TabIndex = 2;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source Database";
            // 
            // btnSrcConnect
            // 
            this.btnSrcConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSrcConnect.Location = new System.Drawing.Point(9, 124);
            this.btnSrcConnect.Name = "btnSrcConnect";
            this.btnSrcConnect.Size = new System.Drawing.Size(185, 23);
            this.btnSrcConnect.TabIndex = 6;
            this.btnSrcConnect.Text = "Connect";
            this.btnSrcConnect.UseVisualStyleBackColor = true;
            this.btnSrcConnect.Click += new System.EventHandler(this.btnSrcConnect_Click);
            // 
            // cbxSrcDatabases
            // 
            this.cbxSrcDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSrcDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSrcDatabases.FormattingEnabled = true;
            this.cbxSrcDatabases.Location = new System.Drawing.Point(9, 153);
            this.cbxSrcDatabases.Name = "cbxSrcDatabases";
            this.cbxSrcDatabases.Size = new System.Drawing.Size(185, 21);
            this.cbxSrcDatabases.TabIndex = 7;
            // 
            // cbxSrcAuth
            // 
            this.cbxSrcAuth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSrcAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSrcAuth.FormattingEnabled = true;
            this.cbxSrcAuth.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cbxSrcAuth.Location = new System.Drawing.Point(9, 44);
            this.cbxSrcAuth.Name = "cbxSrcAuth";
            this.cbxSrcAuth.Size = new System.Drawing.Size(185, 21);
            this.cbxSrcAuth.TabIndex = 3;
            this.cbxSrcAuth.SelectedIndexChanged += new System.EventHandler(this.cbxSrcAuth_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDstConnect);
            this.groupBox1.Controls.Add(this.cbxDstDatabases);
            this.groupBox1.Controls.Add(this.cbxDstAuth);
            this.groupBox1.Controls.Add(this.txtDstPass);
            this.groupBox1.Controls.Add(this.txtDstLogin);
            this.groupBox1.Controls.Add(this.txtDstServer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(209, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 184);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destination Database";
            // 
            // btnDstConnect
            // 
            this.btnDstConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDstConnect.Location = new System.Drawing.Point(6, 124);
            this.btnDstConnect.Name = "btnDstConnect";
            this.btnDstConnect.Size = new System.Drawing.Size(185, 23);
            this.btnDstConnect.TabIndex = 12;
            this.btnDstConnect.Text = "Connect";
            this.btnDstConnect.UseVisualStyleBackColor = true;
            this.btnDstConnect.Click += new System.EventHandler(this.btnDstConnect_Click);
            // 
            // cbxDstDatabases
            // 
            this.cbxDstDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDstDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDstDatabases.FormattingEnabled = true;
            this.cbxDstDatabases.Location = new System.Drawing.Point(6, 153);
            this.cbxDstDatabases.Name = "cbxDstDatabases";
            this.cbxDstDatabases.Size = new System.Drawing.Size(185, 21);
            this.cbxDstDatabases.TabIndex = 13;
            // 
            // cbxDstAuth
            // 
            this.cbxDstAuth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDstAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDstAuth.FormattingEnabled = true;
            this.cbxDstAuth.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cbxDstAuth.Location = new System.Drawing.Point(6, 45);
            this.cbxDstAuth.Name = "cbxDstAuth";
            this.cbxDstAuth.Size = new System.Drawing.Size(185, 21);
            this.cbxDstAuth.TabIndex = 9;
            this.cbxDstAuth.SelectedIndexChanged += new System.EventHandler(this.cbxDstAuth_SelectedIndexChanged);
            // 
            // btnTransfer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnTransfer, 2);
            this.btnTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTransfer.Location = new System.Drawing.Point(3, 432);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(406, 24);
            this.btnTransfer.TabIndex = 14;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // pbTotal
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pbTotal, 2);
            this.pbTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbTotal.Location = new System.Drawing.Point(3, 462);
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Size = new System.Drawing.Size(406, 4);
            this.pbTotal.Step = 1;
            this.pbTotal.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTotal.TabIndex = 15;
            // 
            // btnLoadFromDb
            // 
            this.btnLoadFromDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadFromDb.Location = new System.Drawing.Point(3, 193);
            this.btnLoadFromDb.Name = "btnLoadFromDb";
            this.btnLoadFromDb.Size = new System.Drawing.Size(200, 24);
            this.btnLoadFromDb.TabIndex = 16;
            this.btnLoadFromDb.Text = "Load From Source DB";
            this.btnLoadFromDb.UseVisualStyleBackColor = true;
            this.btnLoadFromDb.Click += new System.EventHandler(this.btnLoadFromDb_Click);
            // 
            // miClearAll
            // 
            this.miClearAll.Name = "miClearAll";
            this.miClearAll.Size = new System.Drawing.Size(157, 22);
            this.miClearAll.Text = "All";
            this.miClearAll.Click += new System.EventHandler(this.miClearAll_Click);
            // 
            // miClearSelected
            // 
            this.miClearSelected.Name = "miClearSelected";
            this.miClearSelected.Size = new System.Drawing.Size(157, 22);
            this.miClearSelected.Text = "Selected";
            this.miClearSelected.Click += new System.EventHandler(this.miClearSelected_Click);
            // 
            // miClearSucceded
            // 
            this.miClearSucceded.Name = "miClearSucceded";
            this.miClearSucceded.Size = new System.Drawing.Size(157, 22);
            this.miClearSucceded.Text = "Succeded Items";
            this.miClearSucceded.Click += new System.EventHandler(this.miClearSucceded_Click);
            // 
            // miClearFailed
            // 
            this.miClearFailed.Name = "miClearFailed";
            this.miClearFailed.Size = new System.Drawing.Size(157, 22);
            this.miClearFailed.Text = "Failed Items";
            this.miClearFailed.Click += new System.EventHandler(this.miClearFailed_Click);
            // 
            // imAutoScroll
            // 
            this.imAutoScroll.Name = "imAutoScroll";
            this.imAutoScroll.Size = new System.Drawing.Size(152, 22);
            this.imAutoScroll.Text = "Auto Scroll";
            this.imAutoScroll.Click += new System.EventHandler(this.imAutoScroll_Click);
            // 
            // txtSrcPass
            // 
            this.txtSrcPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrcPass.Cue = "Password";
            this.txtSrcPass.Location = new System.Drawing.Point(9, 97);
            this.txtSrcPass.Name = "txtSrcPass";
            this.txtSrcPass.Size = new System.Drawing.Size(185, 20);
            this.txtSrcPass.TabIndex = 5;
            this.txtSrcPass.UseSystemPasswordChar = true;
            // 
            // txtSrcLogin
            // 
            this.txtSrcLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrcLogin.Cue = "Login Name";
            this.txtSrcLogin.Location = new System.Drawing.Point(9, 71);
            this.txtSrcLogin.Name = "txtSrcLogin";
            this.txtSrcLogin.Size = new System.Drawing.Size(185, 20);
            this.txtSrcLogin.TabIndex = 4;
            // 
            // txtSrcServer
            // 
            this.txtSrcServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrcServer.Cue = "Server Name";
            this.txtSrcServer.Location = new System.Drawing.Point(9, 19);
            this.txtSrcServer.Name = "txtSrcServer";
            this.txtSrcServer.Size = new System.Drawing.Size(185, 20);
            this.txtSrcServer.TabIndex = 2;
            // 
            // txtDstPass
            // 
            this.txtDstPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDstPass.Cue = "Password";
            this.txtDstPass.Location = new System.Drawing.Point(6, 98);
            this.txtDstPass.Name = "txtDstPass";
            this.txtDstPass.Size = new System.Drawing.Size(185, 20);
            this.txtDstPass.TabIndex = 11;
            this.txtDstPass.UseSystemPasswordChar = true;
            // 
            // txtDstLogin
            // 
            this.txtDstLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDstLogin.Cue = "Login Name";
            this.txtDstLogin.Location = new System.Drawing.Point(6, 72);
            this.txtDstLogin.Name = "txtDstLogin";
            this.txtDstLogin.Size = new System.Drawing.Size(185, 20);
            this.txtDstLogin.TabIndex = 10;
            // 
            // txtDstServer
            // 
            this.txtDstServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDstServer.Cue = "Server Name";
            this.txtDstServer.Location = new System.Drawing.Point(6, 19);
            this.txtDstServer.Name = "txtDstServer";
            this.txtDstServer.Size = new System.Drawing.Size(185, 20);
            this.txtDstServer.TabIndex = 8;
            // 
            // reseedToolStripMenuItem
            // 
            this.reseedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miReseedAll,
            this.miUnreseedAll,
            this.miReseedSelected,
            this.miUnreseedSelected});
            this.reseedToolStripMenuItem.Name = "reseedToolStripMenuItem";
            this.reseedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reseedToolStripMenuItem.Text = "Reseed";
            // 
            // miReseedAll
            // 
            this.miReseedAll.Name = "miReseedAll";
            this.miReseedAll.Size = new System.Drawing.Size(167, 22);
            this.miReseedAll.Text = "Check All";
            this.miReseedAll.Click += new System.EventHandler(this.miReseedAll_Click);
            // 
            // miUnreseedAll
            // 
            this.miUnreseedAll.Name = "miUnreseedAll";
            this.miUnreseedAll.Size = new System.Drawing.Size(167, 22);
            this.miUnreseedAll.Text = "Uncheck All";
            this.miUnreseedAll.Click += new System.EventHandler(this.miUnreseedAll_Click);
            // 
            // miReseedSelected
            // 
            this.miReseedSelected.Name = "miReseedSelected";
            this.miReseedSelected.Size = new System.Drawing.Size(167, 22);
            this.miReseedSelected.Text = "Check Selected";
            this.miReseedSelected.Click += new System.EventHandler(this.miReseedSelected_Click);
            // 
            // miUnreseedSelected
            // 
            this.miUnreseedSelected.Name = "miUnreseedSelected";
            this.miUnreseedSelected.Size = new System.Drawing.Size(167, 22);
            this.miUnreseedSelected.Text = "Uncheck Selected";
            this.miUnreseedSelected.Click += new System.EventHandler(this.miUnreseedSelected_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 469);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private BrightIdeasSoftware.FastDataListView fastDataListView1;
        private System.Windows.Forms.Button btnLoadCsv;
        private BrightIdeasSoftware.BarRenderer barRenderer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpSource;
        private CueTextBox txtSrcPass;
        private CueTextBox txtSrcLogin;
        private CueTextBox txtSrcServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private CueTextBox txtDstPass;
        private CueTextBox txtDstLogin;
        private CueTextBox txtDstServer;
        private System.Windows.Forms.ComboBox cbxSrcAuth;
        private System.Windows.Forms.ComboBox cbxSrcDatabases;
        private System.Windows.Forms.ComboBox cbxDstDatabases;
        private System.Windows.Forms.ComboBox cbxDstAuth;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnSrcConnect;
        private System.Windows.Forms.Button btnDstConnect;
        private System.Windows.Forms.ProgressBar pbTotal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miClear;
        private System.Windows.Forms.Button btnLoadFromDb;
        private System.Windows.Forms.ToolStripMenuItem miClearAll;
        private System.Windows.Forms.ToolStripMenuItem miClearSelected;
        private System.Windows.Forms.ToolStripMenuItem miClearSucceded;
        private System.Windows.Forms.ToolStripMenuItem miClearFailed;
        private System.Windows.Forms.ToolStripMenuItem imAutoScroll;
        private System.Windows.Forms.ToolStripMenuItem reseedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miReseedAll;
        private System.Windows.Forms.ToolStripMenuItem miUnreseedAll;
        private System.Windows.Forms.ToolStripMenuItem miReseedSelected;
        private System.Windows.Forms.ToolStripMenuItem miUnreseedSelected;
    }
}

