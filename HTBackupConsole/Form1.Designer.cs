namespace HTBackupConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addHTBackupServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteHTBackupServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverInstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupSchedulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incrementalBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullBackupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.incrementalBackupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewServer = new System.Windows.Forms.TreeView();
            this.contextMenuStripServerNodeTreeview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.tabControlBackup = new System.Windows.Forms.TabControl();
            this.serverInformationTabPage = new System.Windows.Forms.TabPage();
            this.ssStatusBar = new System.Windows.Forms.StatusStrip();
            this.tsCPU = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsRAM = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsPage = new System.Windows.Forms.ToolStripStatusLabel();
            this.UpdateServerInfo = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerBackup = new System.Windows.Forms.TabPage();
            this.ServerPage = new HTBackupUserControl.BackupPage();
            this.tabPageEssbaseBackupParent = new System.Windows.Forms.TabPage();
            this.tabControlEssbaseBackup = new System.Windows.Forms.TabControl();
            this.tabPageEssbackupApplicationDir = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.tabPageEssbaseBackup = new System.Windows.Forms.TabPage();
            this.pageEssbaseBackup = new HTBackupUserControl.BackupPage();
            this.tabPageSQLServer = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkWindowsAuthentication = new System.Windows.Forms.CheckBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackupLog = new System.Windows.Forms.Button();
            this.btnBackupDB = new System.Windows.Forms.Button();
            this.chkIncremental = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.ddlDatabase = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tabServers = new System.Windows.Forms.TabControl();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.lstLocalInstances = new System.Windows.Forms.ListBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.lstNetworkInstances = new System.Windows.Forms.ListBox();
            this.tabPageCluster = new System.Windows.Forms.TabPage();
            this.backupPageCluster = new HTBackupUserControl.BackupPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.listBoxJobNames = new System.Windows.Forms.ListBox();
            this.btnSavePolicy = new System.Windows.Forms.Button();
            this.btnCancelPolicy = new System.Windows.Forms.Button();
            this.chkBoxCompress = new System.Windows.Forms.CheckBox();
            this.lblWeek = new System.Windows.Forms.Label();
            this.numericUpDownBackupRetension = new System.Windows.Forms.NumericUpDown();
            this.labelDeleteInEvery = new System.Windows.Forms.Label();
            this.lblBackupRetension = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstInstances = new System.Windows.Forms.ComboBox();
            this.lstCounters = new System.Windows.Forms.ComboBox();
            this.lstCats = new System.Windows.Forms.ComboBox();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.perfMain = new System.Diagnostics.PerformanceCounter();
            this.tmrCounter = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBoxMonitoringServers = new System.Windows.Forms.ComboBox();
            this.chkBoxLocalMachine = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripServerNodeTreeview.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControlBackup.SuspendLayout();
            this.serverInformationTabPage.SuspendLayout();
            this.ssStatusBar.SuspendLayout();
            this.ServerBackup.SuspendLayout();
            this.tabPageEssbaseBackupParent.SuspendLayout();
            this.tabControlEssbaseBackup.SuspendLayout();
            this.tabPageEssbackupApplicationDir.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPageEssbaseBackup.SuspendLayout();
            this.tabPageSQLServer.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabServers.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabPageCluster.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBackupRetension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.informationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1263, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverManagementToolStripMenuItem,
            this.backupSchedulerToolStripMenuItem,
            this.servicesControlToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // serverManagementToolStripMenuItem
            // 
            this.serverManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addHTBackupServerToolStripMenuItem,
            this.deleteHTBackupServerToolStripMenuItem,
            this.serverInstallToolStripMenuItem});
            this.serverManagementToolStripMenuItem.Name = "serverManagementToolStripMenuItem";
            this.serverManagementToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serverManagementToolStripMenuItem.Text = "Server Management";
            // 
            // addHTBackupServerToolStripMenuItem
            // 
            this.addHTBackupServerToolStripMenuItem.Name = "addHTBackupServerToolStripMenuItem";
            this.addHTBackupServerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.addHTBackupServerToolStripMenuItem.Text = "Add Server";
            this.addHTBackupServerToolStripMenuItem.Click += new System.EventHandler(this.addHTBackupServerToolStripMenuItem_Click);
            // 
            // deleteHTBackupServerToolStripMenuItem
            // 
            this.deleteHTBackupServerToolStripMenuItem.Name = "deleteHTBackupServerToolStripMenuItem";
            this.deleteHTBackupServerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.deleteHTBackupServerToolStripMenuItem.Text = "Delete Server";
            this.deleteHTBackupServerToolStripMenuItem.Click += new System.EventHandler(this.deleteHTBackupServerToolStripMenuItem_Click);
            // 
            // serverInstallToolStripMenuItem
            // 
            this.serverInstallToolStripMenuItem.Name = "serverInstallToolStripMenuItem";
            this.serverInstallToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.serverInstallToolStripMenuItem.Text = "Server Directory";
            this.serverInstallToolStripMenuItem.Click += new System.EventHandler(this.serverInstallToolStripMenuItem_Click);
            // 
            // backupSchedulerToolStripMenuItem
            // 
            this.backupSchedulerToolStripMenuItem.Name = "backupSchedulerToolStripMenuItem";
            this.backupSchedulerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.backupSchedulerToolStripMenuItem.Text = "Backup Scheduler";
            // 
            // servicesControlToolStripMenuItem
            // 
            this.servicesControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startServicesToolStripMenuItem,
            this.stopServicesToolStripMenuItem});
            this.servicesControlToolStripMenuItem.Name = "servicesControlToolStripMenuItem";
            this.servicesControlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.servicesControlToolStripMenuItem.Text = "Services Control";
            // 
            // startServicesToolStripMenuItem
            // 
            this.startServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullBackupToolStripMenuItem,
            this.incrementalBackupToolStripMenuItem});
            this.startServicesToolStripMenuItem.Name = "startServicesToolStripMenuItem";
            this.startServicesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.startServicesToolStripMenuItem.Text = "Start Services";
            // 
            // fullBackupToolStripMenuItem
            // 
            this.fullBackupToolStripMenuItem.Name = "fullBackupToolStripMenuItem";
            this.fullBackupToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.fullBackupToolStripMenuItem.Text = "Full Backup";
            // 
            // incrementalBackupToolStripMenuItem
            // 
            this.incrementalBackupToolStripMenuItem.Name = "incrementalBackupToolStripMenuItem";
            this.incrementalBackupToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.incrementalBackupToolStripMenuItem.Text = "Incremental Backup";
            // 
            // stopServicesToolStripMenuItem
            // 
            this.stopServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullBackupToolStripMenuItem1,
            this.incrementalBackupToolStripMenuItem1});
            this.stopServicesToolStripMenuItem.Name = "stopServicesToolStripMenuItem";
            this.stopServicesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.stopServicesToolStripMenuItem.Text = "Stop Services";
            // 
            // fullBackupToolStripMenuItem1
            // 
            this.fullBackupToolStripMenuItem1.Name = "fullBackupToolStripMenuItem1";
            this.fullBackupToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.fullBackupToolStripMenuItem1.Text = "Full Backup";
            // 
            // incrementalBackupToolStripMenuItem1
            // 
            this.incrementalBackupToolStripMenuItem1.Name = "incrementalBackupToolStripMenuItem1";
            this.incrementalBackupToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.incrementalBackupToolStripMenuItem1.Text = "Incremental Backup";
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviceStatusToolStripMenuItem});
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.informationToolStripMenuItem.Text = "Information";
            // 
            // serviceStatusToolStripMenuItem
            // 
            this.serviceStatusToolStripMenuItem.Name = "serviceStatusToolStripMenuItem";
            this.serviceStatusToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.serviceStatusToolStripMenuItem.Text = "Service Status";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // treeViewServer
            // 
            this.treeViewServer.ContextMenuStrip = this.contextMenuStripServerNodeTreeview;
            this.treeViewServer.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeViewServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewServer.HideSelection = false;
            this.treeViewServer.ImageIndex = 0;
            this.treeViewServer.ImageList = this.imageList1;
            this.treeViewServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treeViewServer.Location = new System.Drawing.Point(10, 52);
            this.treeViewServer.Name = "treeViewServer";
            this.treeViewServer.SelectedImageIndex = 0;
            this.treeViewServer.Size = new System.Drawing.Size(165, 381);
            this.treeViewServer.TabIndex = 1;
            this.treeViewServer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStripServerNodeTreeview
            // 
            this.contextMenuStripServerNodeTreeview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAdd,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStripServerNodeTreeview.Name = "contextMenuStripServerNodeTreeview";
            this.contextMenuStripServerNodeTreeview.Size = new System.Drawing.Size(113, 70);
            this.contextMenuStripServerNodeTreeview.Text = "Context Menu";
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemAdd.Text = "Add";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "server.jpg");
            this.imageList1.Images.SetKeyName(1, "database.jpg");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton6,
            this.toolStripButton7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1263, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(106, 22);
            this.toolStripButton1.Text = "Refresh Servers";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(84, 22);
            this.toolStripButton2.Text = "Add Server";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(95, 22);
            this.toolStripButton3.Text = "Delete Server";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(108, 22);
            this.toolStripButton4.Text = "Directory Setup";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(107, 22);
            this.toolStripButton6.Text = "Service Control";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(101, 22);
            this.toolStripButton7.Text = "Manage Users";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // tabControlBackup
            // 
            this.tabControlBackup.Controls.Add(this.serverInformationTabPage);
            this.tabControlBackup.Controls.Add(this.ServerBackup);
            this.tabControlBackup.Controls.Add(this.tabPageEssbaseBackupParent);
            this.tabControlBackup.Controls.Add(this.tabPageSQLServer);
            this.tabControlBackup.Controls.Add(this.tabPageCluster);
            this.tabControlBackup.Controls.Add(this.tabPage1);
            this.tabControlBackup.Location = new System.Drawing.Point(184, 53);
            this.tabControlBackup.Name = "tabControlBackup";
            this.tabControlBackup.SelectedIndex = 0;
            this.tabControlBackup.Size = new System.Drawing.Size(1079, 434);
            this.tabControlBackup.TabIndex = 3;
            this.tabControlBackup.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlBackup_Selected);
            // 
            // serverInformationTabPage
            // 
            this.serverInformationTabPage.Controls.Add(this.ssStatusBar);
            this.serverInformationTabPage.Controls.Add(this.UpdateServerInfo);
            this.serverInformationTabPage.Controls.Add(this.textBox4);
            this.serverInformationTabPage.Controls.Add(this.textBox3);
            this.serverInformationTabPage.Controls.Add(this.textBox2);
            this.serverInformationTabPage.Controls.Add(this.textBox1);
            this.serverInformationTabPage.Controls.Add(this.label4);
            this.serverInformationTabPage.Controls.Add(this.label3);
            this.serverInformationTabPage.Controls.Add(this.label2);
            this.serverInformationTabPage.Controls.Add(this.label1);
            this.serverInformationTabPage.Location = new System.Drawing.Point(4, 22);
            this.serverInformationTabPage.Name = "serverInformationTabPage";
            this.serverInformationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.serverInformationTabPage.Size = new System.Drawing.Size(1071, 408);
            this.serverInformationTabPage.TabIndex = 0;
            this.serverInformationTabPage.Text = "Server Information";
            this.serverInformationTabPage.UseVisualStyleBackColor = true;
            // 
            // ssStatusBar
            // 
            this.ssStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCPU,
            this.tsRAM,
            this.tsPage});
            this.ssStatusBar.Location = new System.Drawing.Point(3, 383);
            this.ssStatusBar.Name = "ssStatusBar";
            this.ssStatusBar.ShowItemToolTips = true;
            this.ssStatusBar.Size = new System.Drawing.Size(1065, 22);
            this.ssStatusBar.SizingGrip = false;
            this.ssStatusBar.TabIndex = 9;
            this.ssStatusBar.Text = "statusStrip1";
            // 
            // tsCPU
            // 
            this.tsCPU.AutoSize = false;
            this.tsCPU.AutoToolTip = true;
            this.tsCPU.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsCPU.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tsCPU.Name = "tsCPU";
            this.tsCPU.Size = new System.Drawing.Size(40, 17);
            this.tsCPU.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsCPU.ToolTipText = "CPU Utilization";
            // 
            // tsRAM
            // 
            this.tsRAM.AutoSize = false;
            this.tsRAM.AutoToolTip = true;
            this.tsRAM.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsRAM.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tsRAM.Name = "tsRAM";
            this.tsRAM.Size = new System.Drawing.Size(40, 17);
            this.tsRAM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsRAM.ToolTipText = "Commit Charge";
            // 
            // tsPage
            // 
            this.tsPage.AutoSize = false;
            this.tsPage.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsPage.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tsPage.Name = "tsPage";
            this.tsPage.Size = new System.Drawing.Size(40, 17);
            this.tsPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsPage.ToolTipText = "Page File Usage";
            // 
            // UpdateServerInfo
            // 
            this.UpdateServerInfo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.UpdateServerInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateServerInfo.Location = new System.Drawing.Point(236, 146);
            this.UpdateServerInfo.Name = "UpdateServerInfo";
            this.UpdateServerInfo.Size = new System.Drawing.Size(75, 23);
            this.UpdateServerInfo.TabIndex = 8;
            this.UpdateServerInfo.Text = "Update";
            this.UpdateServerInfo.UseVisualStyleBackColor = true;
            this.UpdateServerInfo.Click += new System.EventHandler(this.UpdateServerInfo_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(116, 106);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(195, 20);
            this.textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(116, 80);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(195, 20);
            this.textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(116, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(195, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(195, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Essbase Admin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Server Admin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server IP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server name:";
            // 
            // ServerBackup
            // 
            this.ServerBackup.Controls.Add(this.ServerPage);
            this.ServerBackup.Location = new System.Drawing.Point(4, 22);
            this.ServerBackup.Name = "ServerBackup";
            this.ServerBackup.Padding = new System.Windows.Forms.Padding(3);
            this.ServerBackup.Size = new System.Drawing.Size(1071, 408);
            this.ServerBackup.TabIndex = 5;
            this.ServerBackup.Text = "Server Backup";
            this.ServerBackup.UseVisualStyleBackColor = true;
            // 
            // ServerPage
            // 
            this.ServerPage.Cursor = System.Windows.Forms.Cursors.Default;
            this.ServerPage.Location = new System.Drawing.Point(6, 6);
            this.ServerPage.Name = "ServerPage";
            this.ServerPage.Size = new System.Drawing.Size(935, 388);
            this.ServerPage.TabIndex = 0;
            // 
            // tabPageEssbaseBackupParent
            // 
            this.tabPageEssbaseBackupParent.Controls.Add(this.tabControlEssbaseBackup);
            this.tabPageEssbaseBackupParent.Location = new System.Drawing.Point(4, 22);
            this.tabPageEssbaseBackupParent.Name = "tabPageEssbaseBackupParent";
            this.tabPageEssbaseBackupParent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEssbaseBackupParent.Size = new System.Drawing.Size(1071, 408);
            this.tabPageEssbaseBackupParent.TabIndex = 1;
            this.tabPageEssbaseBackupParent.Text = "Essbase Backup";
            this.tabPageEssbaseBackupParent.UseVisualStyleBackColor = true;
            // 
            // tabControlEssbaseBackup
            // 
            this.tabControlEssbaseBackup.Controls.Add(this.tabPageEssbackupApplicationDir);
            this.tabControlEssbaseBackup.Controls.Add(this.tabPageEssbaseBackup);
            this.tabControlEssbaseBackup.Location = new System.Drawing.Point(0, 6);
            this.tabControlEssbaseBackup.Name = "tabControlEssbaseBackup";
            this.tabControlEssbaseBackup.SelectedIndex = 0;
            this.tabControlEssbaseBackup.Size = new System.Drawing.Size(1071, 406);
            this.tabControlEssbaseBackup.TabIndex = 0;
            this.tabControlEssbaseBackup.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlEssbaseBackup_Selected);
            // 
            // tabPageEssbackupApplicationDir
            // 
            this.tabPageEssbackupApplicationDir.Controls.Add(this.label23);
            this.tabPageEssbackupApplicationDir.Controls.Add(this.button8);
            this.tabPageEssbackupApplicationDir.Controls.Add(this.textBox15);
            this.tabPageEssbackupApplicationDir.Controls.Add(this.label22);
            this.tabPageEssbackupApplicationDir.Controls.Add(this.toolStrip2);
            this.tabPageEssbackupApplicationDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageEssbackupApplicationDir.Location = new System.Drawing.Point(4, 22);
            this.tabPageEssbackupApplicationDir.Name = "tabPageEssbackupApplicationDir";
            this.tabPageEssbackupApplicationDir.Size = new System.Drawing.Size(1063, 380);
            this.tabPageEssbackupApplicationDir.TabIndex = 2;
            this.tabPageEssbackupApplicationDir.Text = "Application Directory";
            this.tabPageEssbackupApplicationDir.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label23.Location = new System.Drawing.Point(-6, 320);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(289, 13);
            this.label23.TabIndex = 4;
            this.label23.Text = " Directory where your Essbase applications reside";
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(477, 52);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 3;
            this.button8.Text = "Update";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox15
            // 
            this.textBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.Location = new System.Drawing.Point(168, 54);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(303, 20);
            this.textBox15.TabIndex = 2;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(12, 57);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(150, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "Essbase Application Directory:";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton8});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1063, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(118, 22);
            this.toolStripButton8.Text = "Current Directory";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // tabPageEssbaseBackup
            // 
            this.tabPageEssbaseBackup.Controls.Add(this.pageEssbaseBackup);
            this.tabPageEssbaseBackup.Location = new System.Drawing.Point(4, 22);
            this.tabPageEssbaseBackup.Name = "tabPageEssbaseBackup";
            this.tabPageEssbaseBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEssbaseBackup.Size = new System.Drawing.Size(1063, 380);
            this.tabPageEssbaseBackup.TabIndex = 0;
            this.tabPageEssbaseBackup.Text = "Backup";
            this.tabPageEssbaseBackup.UseVisualStyleBackColor = true;
            this.tabPageEssbaseBackup.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // pageEssbaseBackup
            // 
            this.pageEssbaseBackup.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageEssbaseBackup.Location = new System.Drawing.Point(6, -1);
            this.pageEssbaseBackup.Name = "pageEssbaseBackup";
            this.pageEssbaseBackup.Size = new System.Drawing.Size(943, 385);
            this.pageEssbaseBackup.TabIndex = 0;
            // 
            // tabPageSQLServer
            // 
            this.tabPageSQLServer.Controls.Add(this.tabControl3);
            this.tabPageSQLServer.Location = new System.Drawing.Point(4, 22);
            this.tabPageSQLServer.Name = "tabPageSQLServer";
            this.tabPageSQLServer.Size = new System.Drawing.Size(1071, 408);
            this.tabPageSQLServer.TabIndex = 3;
            this.tabPageSQLServer.Text = "Database Backup";
            this.tabPageSQLServer.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Location = new System.Drawing.Point(0, 6);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1071, 362);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox2);
            this.tabPage7.Controls.Add(this.progressBar1);
            this.tabPage7.Controls.Add(this.dataGridView1);
            this.tabPage7.Controls.Add(this.btnVerify);
            this.tabPage7.Controls.Add(this.btnRestore);
            this.tabPage7.Controls.Add(this.btnBackupLog);
            this.tabPage7.Controls.Add(this.btnBackupDB);
            this.tabPage7.Controls.Add(this.chkIncremental);
            this.tabPage7.Controls.Add(this.btnBrowse);
            this.tabPage7.Controls.Add(this.txtFileName);
            this.tabPage7.Controls.Add(this.label33);
            this.tabPage7.Controls.Add(this.ddlDatabase);
            this.tabPage7.Controls.Add(this.label32);
            this.tabPage7.Controls.Add(this.tabServers);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1063, 336);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "SQL Server";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLogin);
            this.groupBox2.Controls.Add(this.lblLogin);
            this.groupBox2.Controls.Add(this.lblPassword);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.chkWindowsAuthentication);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Location = new System.Drawing.Point(430, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 82);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Connectivity";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(56, 21);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(118, 20);
            this.txtLogin.TabIndex = 3;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(8, 24);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(36, 13);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(180, 24);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(242, 23);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(118, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // chkWindowsAuthentication
            // 
            this.chkWindowsAuthentication.AutoSize = true;
            this.chkWindowsAuthentication.Location = new System.Drawing.Point(11, 53);
            this.chkWindowsAuthentication.Name = "chkWindowsAuthentication";
            this.chkWindowsAuthentication.Size = new System.Drawing.Size(163, 17);
            this.chkWindowsAuthentication.TabIndex = 6;
            this.chkWindowsAuthentication.Text = "Use Windows Authentication";
            this.chkWindowsAuthentication.UseVisualStyleBackColor = true;
            this.chkWindowsAuthentication.CheckedChanged += new System.EventHandler(this.chkWindowsAuthentication_CheckedChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(243, 49);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(763, 220);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(294, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(0, 249);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1063, 84);
            this.dataGridView1.TabIndex = 17;
            // 
            // btnVerify
            // 
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Location = new System.Drawing.Point(673, 218);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 16;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Location = new System.Drawing.Point(592, 218);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 15;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackupLog
            // 
            this.btnBackupLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupLog.Location = new System.Drawing.Point(511, 218);
            this.btnBackupLog.Name = "btnBackupLog";
            this.btnBackupLog.Size = new System.Drawing.Size(75, 23);
            this.btnBackupLog.TabIndex = 14;
            this.btnBackupLog.Text = "Backup Log";
            this.btnBackupLog.UseVisualStyleBackColor = true;
            this.btnBackupLog.Click += new System.EventHandler(this.btnBackupLog_Click);
            // 
            // btnBackupDB
            // 
            this.btnBackupDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupDB.Location = new System.Drawing.Point(430, 218);
            this.btnBackupDB.Name = "btnBackupDB";
            this.btnBackupDB.Size = new System.Drawing.Size(75, 23);
            this.btnBackupDB.TabIndex = 13;
            this.btnBackupDB.Text = "Backup";
            this.btnBackupDB.UseVisualStyleBackColor = true;
            this.btnBackupDB.Click += new System.EventHandler(this.btnBackupDB_Click);
            // 
            // chkIncremental
            // 
            this.chkIncremental.AutoSize = true;
            this.chkIncremental.Location = new System.Drawing.Point(430, 195);
            this.chkIncremental.Name = "chkIncremental";
            this.chkIncremental.Size = new System.Drawing.Size(81, 17);
            this.chkIncremental.TabIndex = 12;
            this.chkIncremental.Text = "Incremental";
            this.chkIncremental.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(763, 161);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(31, 23);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(513, 161);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(232, 20);
            this.txtFileName.TabIndex = 10;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(427, 164);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(66, 13);
            this.label33.TabIndex = 9;
            this.label33.Text = "Backup File:";
            // 
            // ddlDatabase
            // 
            this.ddlDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDatabase.FormattingEnabled = true;
            this.ddlDatabase.Location = new System.Drawing.Point(513, 129);
            this.ddlDatabase.Name = "ddlDatabase";
            this.ddlDatabase.Size = new System.Drawing.Size(232, 21);
            this.ddlDatabase.TabIndex = 8;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(427, 132);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(56, 13);
            this.label32.TabIndex = 7;
            this.label32.Text = "Database:";
            // 
            // tabServers
            // 
            this.tabServers.Controls.Add(this.tabPage11);
            this.tabServers.Controls.Add(this.tabPage12);
            this.tabServers.Location = new System.Drawing.Point(0, 6);
            this.tabServers.Name = "tabServers";
            this.tabServers.SelectedIndex = 0;
            this.tabServers.Size = new System.Drawing.Size(412, 235);
            this.tabServers.TabIndex = 0;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.lstLocalInstances);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(404, 209);
            this.tabPage11.TabIndex = 0;
            this.tabPage11.Text = "Local Instances";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // lstLocalInstances
            // 
            this.lstLocalInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLocalInstances.FormattingEnabled = true;
            this.lstLocalInstances.Location = new System.Drawing.Point(3, 3);
            this.lstLocalInstances.Name = "lstLocalInstances";
            this.lstLocalInstances.Size = new System.Drawing.Size(398, 203);
            this.lstLocalInstances.TabIndex = 0;
            this.lstLocalInstances.SelectedIndexChanged += new System.EventHandler(this.lstLocalInstances_SelectedIndexChanged);
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.lstNetworkInstances);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(404, 209);
            this.tabPage12.TabIndex = 1;
            this.tabPage12.Text = "Network Instances";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // lstNetworkInstances
            // 
            this.lstNetworkInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNetworkInstances.FormattingEnabled = true;
            this.lstNetworkInstances.Location = new System.Drawing.Point(3, 3);
            this.lstNetworkInstances.Name = "lstNetworkInstances";
            this.lstNetworkInstances.Size = new System.Drawing.Size(398, 203);
            this.lstNetworkInstances.TabIndex = 0;
            // 
            // tabPageCluster
            // 
            this.tabPageCluster.Controls.Add(this.backupPageCluster);
            this.tabPageCluster.Location = new System.Drawing.Point(4, 22);
            this.tabPageCluster.Name = "tabPageCluster";
            this.tabPageCluster.Size = new System.Drawing.Size(1071, 408);
            this.tabPageCluster.TabIndex = 6;
            this.tabPageCluster.Text = "Essbase Cluster";
            this.tabPageCluster.UseVisualStyleBackColor = true;
            // 
            // backupPageCluster
            // 
            this.backupPageCluster.Cursor = System.Windows.Forms.Cursors.Default;
            this.backupPageCluster.Location = new System.Drawing.Point(4, 4);
            this.backupPageCluster.Name = "backupPageCluster";
            this.backupPageCluster.Size = new System.Drawing.Size(929, 461);
            this.backupPageCluster.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.listBoxJobNames);
            this.tabPage1.Controls.Add(this.btnSavePolicy);
            this.tabPage1.Controls.Add(this.btnCancelPolicy);
            this.tabPage1.Controls.Add(this.chkBoxCompress);
            this.tabPage1.Controls.Add(this.lblWeek);
            this.tabPage1.Controls.Add(this.numericUpDownBackupRetension);
            this.tabPage1.Controls.Add(this.labelDeleteInEvery);
            this.tabPage1.Controls.Add(this.lblBackupRetension);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1071, 408);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "Policies";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "Job Names";
            // 
            // listBoxJobNames
            // 
            this.listBoxJobNames.FormattingEnabled = true;
            this.listBoxJobNames.Location = new System.Drawing.Point(23, 49);
            this.listBoxJobNames.Name = "listBoxJobNames";
            this.listBoxJobNames.Size = new System.Drawing.Size(231, 199);
            this.listBoxJobNames.TabIndex = 62;
            this.listBoxJobNames.SelectedIndexChanged += new System.EventHandler(this.listBoxJobNames_SelectedIndexChanged);
            // 
            // btnSavePolicy
            // 
            this.btnSavePolicy.Location = new System.Drawing.Point(637, 321);
            this.btnSavePolicy.Name = "btnSavePolicy";
            this.btnSavePolicy.Size = new System.Drawing.Size(75, 23);
            this.btnSavePolicy.TabIndex = 61;
            this.btnSavePolicy.Text = "Save";
            this.btnSavePolicy.UseVisualStyleBackColor = true;
            this.btnSavePolicy.Click += new System.EventHandler(this.btnSavePolicy_Click);
            // 
            // btnCancelPolicy
            // 
            this.btnCancelPolicy.Location = new System.Drawing.Point(718, 321);
            this.btnCancelPolicy.Name = "btnCancelPolicy";
            this.btnCancelPolicy.Size = new System.Drawing.Size(75, 23);
            this.btnCancelPolicy.TabIndex = 60;
            this.btnCancelPolicy.Text = "Cancel";
            this.btnCancelPolicy.UseVisualStyleBackColor = true;
            // 
            // chkBoxCompress
            // 
            this.chkBoxCompress.AutoSize = true;
            this.chkBoxCompress.Location = new System.Drawing.Point(279, 97);
            this.chkBoxCompress.Name = "chkBoxCompress";
            this.chkBoxCompress.Size = new System.Drawing.Size(72, 17);
            this.chkBoxCompress.TabIndex = 59;
            this.chkBoxCompress.Text = "Compress";
            this.chkBoxCompress.UseVisualStyleBackColor = true;
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(411, 54);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(36, 13);
            this.lblWeek.TabIndex = 3;
            this.lblWeek.Text = "Week";
            // 
            // numericUpDownBackupRetension
            // 
            this.numericUpDownBackupRetension.Location = new System.Drawing.Point(360, 51);
            this.numericUpDownBackupRetension.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBackupRetension.Name = "numericUpDownBackupRetension";
            this.numericUpDownBackupRetension.Size = new System.Drawing.Size(48, 20);
            this.numericUpDownBackupRetension.TabIndex = 2;
            this.numericUpDownBackupRetension.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelDeleteInEvery
            // 
            this.labelDeleteInEvery.AutoSize = true;
            this.labelDeleteInEvery.Location = new System.Drawing.Point(276, 53);
            this.labelDeleteInEvery.Name = "labelDeleteInEvery";
            this.labelDeleteInEvery.Size = new System.Drawing.Size(78, 13);
            this.labelDeleteInEvery.TabIndex = 1;
            this.labelDeleteInEvery.Text = "Delete in every";
            // 
            // lblBackupRetension
            // 
            this.lblBackupRetension.AutoSize = true;
            this.lblBackupRetension.Location = new System.Drawing.Point(276, 31);
            this.lblBackupRetension.Name = "lblBackupRetension";
            this.lblBackupRetension.Size = new System.Drawing.Size(93, 13);
            this.lblBackupRetension.TabIndex = 0;
            this.lblBackupRetension.Text = "Backup Retention";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(419, 35);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(416, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Start Date:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(107, 24);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(281, 21);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Server:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(107, 137);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(281, 20);
            this.textBox7.TabIndex = 7;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(107, 98);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(281, 20);
            this.textBox6.TabIndex = 3;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(107, 61);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(281, 20);
            this.textBox5.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Application:";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(107, 198);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(313, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Schedule";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Start Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Backup Schedule:";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(181, 515);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(39, 13);
            this.lblValue.TabIndex = 13;
            this.lblValue.Text = "Value";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(611, 491);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Monitor";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstInstances
            // 
            this.lstInstances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstInstances.FormattingEnabled = true;
            this.lstInstances.Location = new System.Drawing.Point(459, 493);
            this.lstInstances.Name = "lstInstances";
            this.lstInstances.Size = new System.Drawing.Size(121, 21);
            this.lstInstances.TabIndex = 11;
            // 
            // lstCounters
            // 
            this.lstCounters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstCounters.FormattingEnabled = true;
            this.lstCounters.Location = new System.Drawing.Point(321, 493);
            this.lstCounters.Name = "lstCounters";
            this.lstCounters.Size = new System.Drawing.Size(121, 21);
            this.lstCounters.TabIndex = 10;
            this.lstCounters.SelectedIndexChanged += new System.EventHandler(this.lstCounters_SelectedIndexChanged);
            // 
            // lstCats
            // 
            this.lstCats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstCats.FormattingEnabled = true;
            this.lstCats.Location = new System.Drawing.Point(184, 493);
            this.lstCats.Name = "lstCats";
            this.lstCats.Size = new System.Drawing.Size(121, 21);
            this.lstCats.TabIndex = 9;
            this.lstCats.SelectedIndexChanged += new System.EventHandler(this.lstCats_SelectedIndexChanged);
            // 
            // picGraph
            // 
            this.picGraph.Image = ((System.Drawing.Image)(resources.GetObject("picGraph.Image")));
            this.picGraph.Location = new System.Drawing.Point(184, 528);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(1075, 189);
            this.picGraph.TabIndex = 8;
            this.picGraph.TabStop = false;
            // 
            // perfMain
            // 
            this.perfMain.CategoryName = "Processor";
            this.perfMain.CounterName = "% Processor Time";
            // 
            // tmrCounter
            // 
            this.tmrCounter.Tick += new System.EventHandler(this.tmrCounter_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 452);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 15);
            this.label5.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBoxMonitoringServers);
            this.groupBox1.Controls.Add(this.chkBoxLocalMachine);
            this.groupBox1.Location = new System.Drawing.Point(18, 435);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 83);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Monitoring";
            // 
            // cmbBoxMonitoringServers
            // 
            this.cmbBoxMonitoringServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxMonitoringServers.FormattingEnabled = true;
            this.cmbBoxMonitoringServers.Location = new System.Drawing.Point(6, 51);
            this.cmbBoxMonitoringServers.Name = "cmbBoxMonitoringServers";
            this.cmbBoxMonitoringServers.Size = new System.Drawing.Size(123, 21);
            this.cmbBoxMonitoringServers.TabIndex = 0;
            this.cmbBoxMonitoringServers.SelectedIndexChanged += new System.EventHandler(this.cmbBoxMonitoringServers_SelectedIndexChanged);
            // 
            // chkBoxLocalMachine
            // 
            this.chkBoxLocalMachine.AutoSize = true;
            this.chkBoxLocalMachine.Location = new System.Drawing.Point(6, 24);
            this.chkBoxLocalMachine.Name = "chkBoxLocalMachine";
            this.chkBoxLocalMachine.Size = new System.Drawing.Size(96, 17);
            this.chkBoxLocalMachine.TabIndex = 1;
            this.chkBoxLocalMachine.Text = "Local Machine";
            this.chkBoxLocalMachine.UseVisualStyleBackColor = true;
            this.chkBoxLocalMachine.CheckedChanged += new System.EventHandler(this.chkBoxLocalMachine_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 736);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lstInstances);
            this.Controls.Add(this.tabControlBackup);
            this.Controls.Add(this.lstCounters);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lstCats);
            this.Controls.Add(this.treeViewServer);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.picGraph);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "HTBackup Management Console";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripServerNodeTreeview.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControlBackup.ResumeLayout(false);
            this.serverInformationTabPage.ResumeLayout(false);
            this.serverInformationTabPage.PerformLayout();
            this.ssStatusBar.ResumeLayout(false);
            this.ssStatusBar.PerformLayout();
            this.ServerBackup.ResumeLayout(false);
            this.tabPageEssbaseBackupParent.ResumeLayout(false);
            this.tabControlEssbaseBackup.ResumeLayout(false);
            this.tabPageEssbackupApplicationDir.ResumeLayout(false);
            this.tabPageEssbackupApplicationDir.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPageEssbaseBackup.ResumeLayout(false);
            this.tabPageSQLServer.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabServers.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.tabPageCluster.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBackupRetension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupSchedulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incrementalBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullBackupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem incrementalBackupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem serverManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addHTBackupServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteHTBackupServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceStatusToolStripMenuItem;
        private System.Windows.Forms.TreeView treeViewServer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem serverInstallToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.TabControl tabControlBackup;
        private System.Windows.Forms.TabPage serverInformationTabPage;
        private System.Windows.Forms.TabPage tabPageEssbaseBackupParent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Diagnostics.PerformanceCounter perfMain;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.Timer tmrCounter;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox lstInstances;
        private System.Windows.Forms.ComboBox lstCounters;
        private System.Windows.Forms.ComboBox lstCats;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button UpdateServerInfo;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.TabPage tabPageSQLServer;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.StatusStrip ssStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel tsCPU;
        private System.Windows.Forms.ToolStripStatusLabel tsRAM;
        private System.Windows.Forms.ToolStripStatusLabel tsPage;
        private System.Windows.Forms.TabControl tabServers;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.ListBox lstLocalInstances;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.CheckBox chkWindowsAuthentication;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackupLog;
        private System.Windows.Forms.Button btnBackupDB;
        private System.Windows.Forms.CheckBox chkIncremental;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox ddlDatabase;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ListBox lstNetworkInstances;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripServerNodeTreeview;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlEssbaseBackup;
        private System.Windows.Forms.TabPage tabPageEssbackupApplicationDir;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.TabPage tabPageEssbaseBackup;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBoxLocalMachine;
        private System.Windows.Forms.ComboBox cmbBoxMonitoringServers;
        private System.Windows.Forms.TabPage ServerBackup;
        private HTBackupUserControl.BackupPage ServerPage;
        private HTBackupUserControl.BackupPage pageEssbaseBackup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPageCluster;
        private HTBackupUserControl.BackupPage backupPageCluster;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblBackupRetension;
        private System.Windows.Forms.NumericUpDown numericUpDownBackupRetension;
        private System.Windows.Forms.Label labelDeleteInEvery;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.CheckBox chkBoxCompress;
        private System.Windows.Forms.Button btnSavePolicy;
        private System.Windows.Forms.Button btnCancelPolicy;
        private System.Windows.Forms.ListBox listBoxJobNames;
        private System.Windows.Forms.Label label9;
    }
}

