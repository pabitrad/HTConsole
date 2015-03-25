namespace HTBackupUserControl
{
    partial class BackupPage
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.lblJobName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddSorceLocation = new System.Windows.Forms.Button();
            this.listboxSourceLocations = new System.Windows.Forms.ListBox();
            this.groupBoxFolderLocations = new System.Windows.Forms.GroupBox();
            this.chkBoxIncremental = new System.Windows.Forms.CheckBox();
            this.grpBoxIncremental = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.listBoxJobs = new System.Windows.Forms.ListView();
            this.jobName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxJobDetails = new System.Windows.Forms.GroupBox();
            this.btnDeleteTrigger = new System.Windows.Forms.Button();
            this.btnEditTrigger = new System.Windows.Forms.Button();
            this.btnNewTrigger = new System.Windows.Forms.Button();
            this.listViewTriggers = new System.Windows.Forms.ListView();
            this.trigger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.triggerDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.triggerStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblLogFileLocation = new System.Windows.Forms.Label();
            this.btnBrowseBackupLocation = new System.Windows.Forms.Button();
            this.lblBackupLocation = new System.Windows.Forms.Label();
            this.txtboxBackupLocation = new System.Windows.Forms.TextBox();
            this.txtboxLogFileLocation = new System.Windows.Forms.TextBox();
            this.btnBrowseLogDir = new System.Windows.Forms.Button();
            this.btnDeleteJob = new System.Windows.Forms.Button();
            this.btnNewJob = new System.Windows.Forms.Button();
            this.grpBoxJobOptions = new System.Windows.Forms.GroupBox();
            this.chkStorePassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chkHighestPrivilege = new System.Windows.Forms.CheckBox();
            this.txtRunAsUser = new System.Windows.Forms.TextBox();
            this.lblRunAsUser = new System.Windows.Forms.Label();
            this.groupBoxFolderLocations.SuspendLayout();
            this.grpBoxIncremental.SuspendLayout();
            this.groupBoxJobDetails.SuspendLayout();
            this.grpBoxJobOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(156, 28);
            this.txtJobName.Margin = new System.Windows.Forms.Padding(4);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(312, 22);
            this.txtJobName.TabIndex = 54;
            this.txtJobName.WordWrap = false;
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.Location = new System.Drawing.Point(75, 32);
            this.lblJobName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(72, 17);
            this.lblJobName.TabIndex = 53;
            this.lblJobName.Text = "Job Name";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(721, 406);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 28);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(117, 212);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 28);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddSorceLocation
            // 
            this.btnAddSorceLocation.Location = new System.Drawing.Point(225, 212);
            this.btnAddSorceLocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSorceLocation.Name = "btnAddSorceLocation";
            this.btnAddSorceLocation.Size = new System.Drawing.Size(100, 28);
            this.btnAddSorceLocation.TabIndex = 1;
            this.btnAddSorceLocation.Text = "Add";
            this.btnAddSorceLocation.UseVisualStyleBackColor = true;
            this.btnAddSorceLocation.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listboxSourceLocations
            // 
            this.listboxSourceLocations.FormattingEnabled = true;
            this.listboxSourceLocations.HorizontalScrollbar = true;
            this.listboxSourceLocations.ItemHeight = 16;
            this.listboxSourceLocations.Location = new System.Drawing.Point(8, 23);
            this.listboxSourceLocations.Margin = new System.Windows.Forms.Padding(4);
            this.listboxSourceLocations.Name = "listboxSourceLocations";
            this.listboxSourceLocations.Size = new System.Drawing.Size(312, 180);
            this.listboxSourceLocations.TabIndex = 0;
            // 
            // groupBoxFolderLocations
            // 
            this.groupBoxFolderLocations.Controls.Add(this.btnRemove);
            this.groupBoxFolderLocations.Controls.Add(this.btnAddSorceLocation);
            this.groupBoxFolderLocations.Controls.Add(this.listboxSourceLocations);
            this.groupBoxFolderLocations.Location = new System.Drawing.Point(495, 23);
            this.groupBoxFolderLocations.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxFolderLocations.Name = "groupBoxFolderLocations";
            this.groupBoxFolderLocations.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxFolderLocations.Size = new System.Drawing.Size(333, 251);
            this.groupBoxFolderLocations.TabIndex = 45;
            this.groupBoxFolderLocations.TabStop = false;
            this.groupBoxFolderLocations.Text = "Folder Locations";
            // 
            // chkBoxIncremental
            // 
            this.chkBoxIncremental.AutoSize = true;
            this.chkBoxIncremental.Location = new System.Drawing.Point(13, 27);
            this.chkBoxIncremental.Margin = new System.Windows.Forms.Padding(4);
            this.chkBoxIncremental.Name = "chkBoxIncremental";
            this.chkBoxIncremental.Size = new System.Drawing.Size(103, 21);
            this.chkBoxIncremental.TabIndex = 23;
            this.chkBoxIncremental.Text = "Incremental";
            this.chkBoxIncremental.UseVisualStyleBackColor = true;
            this.chkBoxIncremental.CheckedChanged += new System.EventHandler(this.chkBoxIncremental_CheckedChanged);
            // 
            // grpBoxIncremental
            // 
            this.grpBoxIncremental.Controls.Add(this.chkBoxIncremental);
            this.grpBoxIncremental.Location = new System.Drawing.Point(19, 68);
            this.grpBoxIncremental.Margin = new System.Windows.Forms.Padding(4);
            this.grpBoxIncremental.Name = "grpBoxIncremental";
            this.grpBoxIncremental.Padding = new System.Windows.Forms.Padding(4);
            this.grpBoxIncremental.Size = new System.Drawing.Size(451, 62);
            this.grpBoxIncremental.TabIndex = 51;
            this.grpBoxIncremental.TabStop = false;
            this.grpBoxIncremental.Text = "Backup Type";
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(613, 406);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 28);
            this.btnReset.TabIndex = 43;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // listBoxJobs
            // 
            this.listBoxJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.jobName});
            this.listBoxJobs.FullRowSelect = true;
            this.listBoxJobs.HideSelection = false;
            this.listBoxJobs.Location = new System.Drawing.Point(8, 30);
            this.listBoxJobs.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxJobs.MultiSelect = false;
            this.listBoxJobs.Name = "listBoxJobs";
            this.listBoxJobs.ShowGroups = false;
            this.listBoxJobs.Size = new System.Drawing.Size(397, 282);
            this.listBoxJobs.TabIndex = 57;
            this.listBoxJobs.UseCompatibleStateImageBehavior = false;
            this.listBoxJobs.View = System.Windows.Forms.View.Details;
            this.listBoxJobs.SelectedIndexChanged += new System.EventHandler(this.listBoxJobs_SelectedIndexChanged);
            // 
            // jobName
            // 
            this.jobName.Text = "Job Name";
            this.jobName.Width = 250;
            // 
            // groupBoxJobDetails
            // 
            this.groupBoxJobDetails.Controls.Add(this.btnDeleteTrigger);
            this.groupBoxJobDetails.Controls.Add(this.btnEditTrigger);
            this.groupBoxJobDetails.Controls.Add(this.btnNewTrigger);
            this.groupBoxJobDetails.Controls.Add(this.listViewTriggers);
            this.groupBoxJobDetails.Controls.Add(this.lblLogFileLocation);
            this.groupBoxJobDetails.Controls.Add(this.btnBrowseBackupLocation);
            this.groupBoxJobDetails.Controls.Add(this.lblBackupLocation);
            this.groupBoxJobDetails.Controls.Add(this.txtJobName);
            this.groupBoxJobDetails.Controls.Add(this.lblJobName);
            this.groupBoxJobDetails.Controls.Add(this.txtboxBackupLocation);
            this.groupBoxJobDetails.Controls.Add(this.groupBoxFolderLocations);
            this.groupBoxJobDetails.Controls.Add(this.txtboxLogFileLocation);
            this.groupBoxJobDetails.Controls.Add(this.btnBrowseLogDir);
            this.groupBoxJobDetails.Controls.Add(this.grpBoxIncremental);
            this.groupBoxJobDetails.Controls.Add(this.btnReset);
            this.groupBoxJobDetails.Controls.Add(this.btnSave);
            this.groupBoxJobDetails.Location = new System.Drawing.Point(415, 20);
            this.groupBoxJobDetails.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxJobDetails.Name = "groupBoxJobDetails";
            this.groupBoxJobDetails.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxJobDetails.Size = new System.Drawing.Size(877, 452);
            this.groupBoxJobDetails.TabIndex = 58;
            this.groupBoxJobDetails.TabStop = false;
            this.groupBoxJobDetails.Text = "Job Details";
            // 
            // btnDeleteTrigger
            // 
            this.btnDeleteTrigger.Location = new System.Drawing.Point(371, 361);
            this.btnDeleteTrigger.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteTrigger.Name = "btnDeleteTrigger";
            this.btnDeleteTrigger.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteTrigger.TabIndex = 61;
            this.btnDeleteTrigger.Text = "Delete";
            this.btnDeleteTrigger.UseVisualStyleBackColor = true;
            this.btnDeleteTrigger.Click += new System.EventHandler(this.btnDeleteTrigger_Click);
            // 
            // btnEditTrigger
            // 
            this.btnEditTrigger.Location = new System.Drawing.Point(253, 361);
            this.btnEditTrigger.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditTrigger.Name = "btnEditTrigger";
            this.btnEditTrigger.Size = new System.Drawing.Size(100, 28);
            this.btnEditTrigger.TabIndex = 61;
            this.btnEditTrigger.Text = "Edit";
            this.btnEditTrigger.UseVisualStyleBackColor = true;
            this.btnEditTrigger.Click += new System.EventHandler(this.btnEditTrigger_Click);
            // 
            // btnNewTrigger
            // 
            this.btnNewTrigger.Location = new System.Drawing.Point(135, 361);
            this.btnNewTrigger.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewTrigger.Name = "btnNewTrigger";
            this.btnNewTrigger.Size = new System.Drawing.Size(100, 28);
            this.btnNewTrigger.TabIndex = 61;
            this.btnNewTrigger.Text = "New";
            this.btnNewTrigger.UseVisualStyleBackColor = true;
            this.btnNewTrigger.Click += new System.EventHandler(this.btnNewTrigger_Click);
            // 
            // listViewTriggers
            // 
            this.listViewTriggers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.trigger,
            this.triggerDetails,
            this.triggerStatus});
            this.listViewTriggers.FullRowSelect = true;
            this.listViewTriggers.HideSelection = false;
            this.listViewTriggers.Location = new System.Drawing.Point(19, 137);
            this.listViewTriggers.Margin = new System.Windows.Forms.Padding(4);
            this.listViewTriggers.MultiSelect = false;
            this.listViewTriggers.Name = "listViewTriggers";
            this.listViewTriggers.ShowGroups = false;
            this.listViewTriggers.Size = new System.Drawing.Size(449, 216);
            this.listViewTriggers.TabIndex = 61;
            this.listViewTriggers.UseCompatibleStateImageBehavior = false;
            this.listViewTriggers.View = System.Windows.Forms.View.Details;
            this.listViewTriggers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewTriggers_MouseDoubleClick);
            // 
            // trigger
            // 
            this.trigger.Text = "Trigger";
            this.trigger.Width = 50;
            // 
            // triggerDetails
            // 
            this.triggerDetails.Text = "Details";
            this.triggerDetails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.triggerDetails.Width = 230;
            // 
            // triggerStatus
            // 
            this.triggerStatus.Text = "Status";
            this.triggerStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.triggerStatus.Width = 53;
            // 
            // lblLogFileLocation
            // 
            this.lblLogFileLocation.AutoSize = true;
            this.lblLogFileLocation.Location = new System.Drawing.Point(489, 299);
            this.lblLogFileLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogFileLocation.Name = "lblLogFileLocation";
            this.lblLogFileLocation.Size = new System.Drawing.Size(116, 17);
            this.lblLogFileLocation.TabIndex = 61;
            this.lblLogFileLocation.Text = "Log File Location";
            // 
            // btnBrowseBackupLocation
            // 
            this.btnBrowseBackupLocation.Location = new System.Drawing.Point(757, 363);
            this.btnBrowseBackupLocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseBackupLocation.Name = "btnBrowseBackupLocation";
            this.btnBrowseBackupLocation.Size = new System.Drawing.Size(71, 28);
            this.btnBrowseBackupLocation.TabIndex = 58;
            this.btnBrowseBackupLocation.Text = "Browse";
            this.btnBrowseBackupLocation.UseVisualStyleBackColor = true;
            this.btnBrowseBackupLocation.Click += new System.EventHandler(this.btnBrowseBackupLocation_Click);
            // 
            // lblBackupLocation
            // 
            this.lblBackupLocation.AutoSize = true;
            this.lblBackupLocation.Location = new System.Drawing.Point(489, 348);
            this.lblBackupLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackupLocation.Name = "lblBackupLocation";
            this.lblBackupLocation.Size = new System.Drawing.Size(113, 17);
            this.lblBackupLocation.TabIndex = 57;
            this.lblBackupLocation.Text = "Backup Location";
            // 
            // txtboxBackupLocation
            // 
            this.txtboxBackupLocation.Location = new System.Drawing.Point(495, 366);
            this.txtboxBackupLocation.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxBackupLocation.Name = "txtboxBackupLocation";
            this.txtboxBackupLocation.Size = new System.Drawing.Size(257, 22);
            this.txtboxBackupLocation.TabIndex = 56;
            // 
            // txtboxLogFileLocation
            // 
            this.txtboxLogFileLocation.Location = new System.Drawing.Point(493, 315);
            this.txtboxLogFileLocation.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxLogFileLocation.Name = "txtboxLogFileLocation";
            this.txtboxLogFileLocation.Size = new System.Drawing.Size(255, 22);
            this.txtboxLogFileLocation.TabIndex = 59;
            // 
            // btnBrowseLogDir
            // 
            this.btnBrowseLogDir.Location = new System.Drawing.Point(755, 311);
            this.btnBrowseLogDir.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseLogDir.Name = "btnBrowseLogDir";
            this.btnBrowseLogDir.Size = new System.Drawing.Size(75, 28);
            this.btnBrowseLogDir.TabIndex = 60;
            this.btnBrowseLogDir.Text = "Browse";
            this.btnBrowseLogDir.UseVisualStyleBackColor = true;
            this.btnBrowseLogDir.Click += new System.EventHandler(this.btnBrowseLogDir_Click);
            // 
            // btnDeleteJob
            // 
            this.btnDeleteJob.Location = new System.Drawing.Point(141, 324);
            this.btnDeleteJob.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteJob.Name = "btnDeleteJob";
            this.btnDeleteJob.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteJob.TabIndex = 59;
            this.btnDeleteJob.Text = "Delete";
            this.btnDeleteJob.UseVisualStyleBackColor = true;
            this.btnDeleteJob.Click += new System.EventHandler(this.btnDeleteJob_Click);
            // 
            // btnNewJob
            // 
            this.btnNewJob.Location = new System.Drawing.Point(256, 324);
            this.btnNewJob.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewJob.Name = "btnNewJob";
            this.btnNewJob.Size = new System.Drawing.Size(100, 28);
            this.btnNewJob.TabIndex = 60;
            this.btnNewJob.Text = "New";
            this.btnNewJob.UseVisualStyleBackColor = true;
            this.btnNewJob.Click += new System.EventHandler(this.btnNewJob_Click);
            // 
            // grpBoxJobOptions
            // 
            this.grpBoxJobOptions.Controls.Add(this.chkStorePassword);
            this.grpBoxJobOptions.Controls.Add(this.txtPassword);
            this.grpBoxJobOptions.Controls.Add(this.lblPassword);
            this.grpBoxJobOptions.Controls.Add(this.chkHighestPrivilege);
            this.grpBoxJobOptions.Controls.Add(this.txtRunAsUser);
            this.grpBoxJobOptions.Controls.Add(this.lblRunAsUser);
            this.grpBoxJobOptions.Location = new System.Drawing.Point(8, 359);
            this.grpBoxJobOptions.Margin = new System.Windows.Forms.Padding(4);
            this.grpBoxJobOptions.Name = "grpBoxJobOptions";
            this.grpBoxJobOptions.Padding = new System.Windows.Forms.Padding(4);
            this.grpBoxJobOptions.Size = new System.Drawing.Size(399, 112);
            this.grpBoxJobOptions.TabIndex = 61;
            this.grpBoxJobOptions.TabStop = false;
            this.grpBoxJobOptions.Text = "Job Options";
            // 
            // chkStorePassword
            // 
            this.chkStorePassword.AutoSize = true;
            this.chkStorePassword.Location = new System.Drawing.Point(251, 70);
            this.chkStorePassword.Margin = new System.Windows.Forms.Padding(4);
            this.chkStorePassword.Name = "chkStorePassword";
            this.chkStorePassword.Size = new System.Drawing.Size(129, 21);
            this.chkStorePassword.TabIndex = 5;
            this.chkStorePassword.Text = "Store Password";
            this.chkStorePassword.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(101, 68);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(140, 22);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(29, 71);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // chkHighestPrivilege
            // 
            this.chkHighestPrivilege.AutoSize = true;
            this.chkHighestPrivilege.Checked = true;
            this.chkHighestPrivilege.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighestPrivilege.Location = new System.Drawing.Point(251, 30);
            this.chkHighestPrivilege.Margin = new System.Windows.Forms.Padding(4);
            this.chkHighestPrivilege.Name = "chkHighestPrivilege";
            this.chkHighestPrivilege.Size = new System.Drawing.Size(136, 21);
            this.chkHighestPrivilege.TabIndex = 2;
            this.chkHighestPrivilege.Text = "Highest Privilege";
            this.chkHighestPrivilege.UseVisualStyleBackColor = true;
            // 
            // txtRunAsUser
            // 
            this.txtRunAsUser.Location = new System.Drawing.Point(101, 27);
            this.txtRunAsUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtRunAsUser.Name = "txtRunAsUser";
            this.txtRunAsUser.Size = new System.Drawing.Size(140, 22);
            this.txtRunAsUser.TabIndex = 1;
            // 
            // lblRunAsUser
            // 
            this.lblRunAsUser.AutoSize = true;
            this.lblRunAsUser.Location = new System.Drawing.Point(11, 30);
            this.lblRunAsUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRunAsUser.Name = "lblRunAsUser";
            this.lblRunAsUser.Size = new System.Drawing.Size(88, 17);
            this.lblRunAsUser.TabIndex = 0;
            this.lblRunAsUser.Text = "Run As User";
            // 
            // BackupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxJobOptions);
            this.Controls.Add(this.btnNewJob);
            this.Controls.Add(this.btnDeleteJob);
            this.Controls.Add(this.groupBoxJobDetails);
            this.Controls.Add(this.listBoxJobs);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BackupPage";
            this.Size = new System.Drawing.Size(1277, 480);
            this.Load += new System.EventHandler(this.BackupPage_Load);
            this.groupBoxFolderLocations.ResumeLayout(false);
            this.grpBoxIncremental.ResumeLayout(false);
            this.grpBoxIncremental.PerformLayout();
            this.groupBoxJobDetails.ResumeLayout(false);
            this.groupBoxJobDetails.PerformLayout();
            this.grpBoxJobOptions.ResumeLayout(false);
            this.grpBoxJobOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddSorceLocation;
        private System.Windows.Forms.ListBox listboxSourceLocations;
        private System.Windows.Forms.GroupBox groupBoxFolderLocations;
        private System.Windows.Forms.CheckBox chkBoxIncremental;
        private System.Windows.Forms.GroupBox grpBoxIncremental;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView listBoxJobs;
        private System.Windows.Forms.ColumnHeader jobName;
        private System.Windows.Forms.GroupBox groupBoxJobDetails;
        private System.Windows.Forms.Label lblLogFileLocation;
        private System.Windows.Forms.Button btnBrowseBackupLocation;
        private System.Windows.Forms.Label lblBackupLocation;
        private System.Windows.Forms.TextBox txtboxBackupLocation;
        private System.Windows.Forms.TextBox txtboxLogFileLocation;
        private System.Windows.Forms.Button btnBrowseLogDir;
        private System.Windows.Forms.Button btnDeleteJob;
        private System.Windows.Forms.Button btnNewJob;
        private System.Windows.Forms.ListView listViewTriggers;
        private System.Windows.Forms.ColumnHeader trigger;
        private System.Windows.Forms.ColumnHeader triggerDetails;
        private System.Windows.Forms.ColumnHeader triggerStatus;
        private System.Windows.Forms.Button btnDeleteTrigger;
        private System.Windows.Forms.Button btnEditTrigger;
        private System.Windows.Forms.Button btnNewTrigger;
        private System.Windows.Forms.GroupBox grpBoxJobOptions;
        private System.Windows.Forms.TextBox txtRunAsUser;
        private System.Windows.Forms.Label lblRunAsUser;
        private System.Windows.Forms.CheckBox chkHighestPrivilege;
        private System.Windows.Forms.CheckBox chkStorePassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
    }
}
