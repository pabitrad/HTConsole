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
            this.lblIncremental = new System.Windows.Forms.Label();
            this.groupBoxFolderLocations = new System.Windows.Forms.GroupBox();
            this.chkBoxIncremental = new System.Windows.Forms.CheckBox();
            this.grpBoxIncremental = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownBackupIncremental = new System.Windows.Forms.NumericUpDown();
            this.btnReset = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
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
            this.groupBoxFolderLocations.SuspendLayout();
            this.grpBoxIncremental.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBackupIncremental)).BeginInit();
            this.groupBoxJobDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(117, 19);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(235, 20);
            this.txtJobName.TabIndex = 54;
            this.txtJobName.WordWrap = false;
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.Location = new System.Drawing.Point(56, 22);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(55, 13);
            this.lblJobName.TabIndex = 53;
            this.lblJobName.Text = "Job Name";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(541, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(88, 172);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddSorceLocation
            // 
            this.btnAddSorceLocation.Location = new System.Drawing.Point(169, 172);
            this.btnAddSorceLocation.Name = "btnAddSorceLocation";
            this.btnAddSorceLocation.Size = new System.Drawing.Size(75, 23);
            this.btnAddSorceLocation.TabIndex = 1;
            this.btnAddSorceLocation.Text = "Add";
            this.btnAddSorceLocation.UseVisualStyleBackColor = true;
            this.btnAddSorceLocation.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listboxSourceLocations
            // 
            this.listboxSourceLocations.FormattingEnabled = true;
            this.listboxSourceLocations.Location = new System.Drawing.Point(6, 19);
            this.listboxSourceLocations.Name = "listboxSourceLocations";
            this.listboxSourceLocations.Size = new System.Drawing.Size(235, 147);
            this.listboxSourceLocations.TabIndex = 0;
            // 
            // lblIncremental
            // 
            this.lblIncremental.AutoSize = true;
            this.lblIncremental.Enabled = false;
            this.lblIncremental.Location = new System.Drawing.Point(162, 23);
            this.lblIncremental.Name = "lblIncremental";
            this.lblIncremental.Size = new System.Drawing.Size(42, 13);
            this.lblIncremental.TabIndex = 25;
            this.lblIncremental.Text = "Interval";
            // 
            // groupBoxFolderLocations
            // 
            this.groupBoxFolderLocations.Controls.Add(this.btnRemove);
            this.groupBoxFolderLocations.Controls.Add(this.btnAddSorceLocation);
            this.groupBoxFolderLocations.Controls.Add(this.listboxSourceLocations);
            this.groupBoxFolderLocations.Location = new System.Drawing.Point(371, 19);
            this.groupBoxFolderLocations.Name = "groupBoxFolderLocations";
            this.groupBoxFolderLocations.Size = new System.Drawing.Size(250, 204);
            this.groupBoxFolderLocations.TabIndex = 45;
            this.groupBoxFolderLocations.TabStop = false;
            this.groupBoxFolderLocations.Text = "Folder Locations";
            // 
            // chkBoxIncremental
            // 
            this.chkBoxIncremental.AutoSize = true;
            this.chkBoxIncremental.Location = new System.Drawing.Point(10, 22);
            this.chkBoxIncremental.Name = "chkBoxIncremental";
            this.chkBoxIncremental.Size = new System.Drawing.Size(81, 17);
            this.chkBoxIncremental.TabIndex = 23;
            this.chkBoxIncremental.Text = "Incremental";
            this.chkBoxIncremental.UseVisualStyleBackColor = true;
            this.chkBoxIncremental.CheckedChanged += new System.EventHandler(this.chkBoxIncremental_CheckedChanged);
            // 
            // grpBoxIncremental
            // 
            this.grpBoxIncremental.Controls.Add(this.label1);
            this.grpBoxIncremental.Controls.Add(this.numericUpDownBackupIncremental);
            this.grpBoxIncremental.Controls.Add(this.lblIncremental);
            this.grpBoxIncremental.Controls.Add(this.chkBoxIncremental);
            this.grpBoxIncremental.Location = new System.Drawing.Point(14, 55);
            this.grpBoxIncremental.Name = "grpBoxIncremental";
            this.grpBoxIncremental.Size = new System.Drawing.Size(338, 50);
            this.grpBoxIncremental.TabIndex = 51;
            this.grpBoxIncremental.TabStop = false;
            this.grpBoxIncremental.Text = "Backup Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(283, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Minutes";
            // 
            // numericUpDownBackupIncremental
            // 
            this.numericUpDownBackupIncremental.Enabled = false;
            this.numericUpDownBackupIncremental.Location = new System.Drawing.Point(207, 20);
            this.numericUpDownBackupIncremental.Name = "numericUpDownBackupIncremental";
            this.numericUpDownBackupIncremental.Size = new System.Drawing.Size(76, 20);
            this.numericUpDownBackupIncremental.TabIndex = 26;
            this.numericUpDownBackupIncremental.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(460, 330);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
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
            this.listBoxJobs.Location = new System.Drawing.Point(6, 24);
            this.listBoxJobs.MultiSelect = false;
            this.listBoxJobs.Name = "listBoxJobs";
            this.listBoxJobs.ShowGroups = false;
            this.listBoxJobs.Size = new System.Drawing.Size(261, 290);
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
            this.groupBoxJobDetails.Location = new System.Drawing.Point(285, 16);
            this.groupBoxJobDetails.Name = "groupBoxJobDetails";
            this.groupBoxJobDetails.Size = new System.Drawing.Size(640, 367);
            this.groupBoxJobDetails.TabIndex = 58;
            this.groupBoxJobDetails.TabStop = false;
            this.groupBoxJobDetails.Text = "Job Details";
            // 
            // btnDeleteTrigger
            // 
            this.btnDeleteTrigger.Location = new System.Drawing.Point(278, 293);
            this.btnDeleteTrigger.Name = "btnDeleteTrigger";
            this.btnDeleteTrigger.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTrigger.TabIndex = 61;
            this.btnDeleteTrigger.Text = "Delete";
            this.btnDeleteTrigger.UseVisualStyleBackColor = true;
            this.btnDeleteTrigger.Click += new System.EventHandler(this.btnDeleteTrigger_Click);
            // 
            // btnEditTrigger
            // 
            this.btnEditTrigger.Location = new System.Drawing.Point(190, 293);
            this.btnEditTrigger.Name = "btnEditTrigger";
            this.btnEditTrigger.Size = new System.Drawing.Size(75, 23);
            this.btnEditTrigger.TabIndex = 61;
            this.btnEditTrigger.Text = "Edit";
            this.btnEditTrigger.UseVisualStyleBackColor = true;
            this.btnEditTrigger.Click += new System.EventHandler(this.btnEditTrigger_Click);
            // 
            // btnNewTrigger
            // 
            this.btnNewTrigger.Location = new System.Drawing.Point(101, 293);
            this.btnNewTrigger.Name = "btnNewTrigger";
            this.btnNewTrigger.Size = new System.Drawing.Size(75, 23);
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
            this.listViewTriggers.Location = new System.Drawing.Point(14, 126);
            this.listViewTriggers.MultiSelect = false;
            this.listViewTriggers.Name = "listViewTriggers";
            this.listViewTriggers.ShowGroups = false;
            this.listViewTriggers.Size = new System.Drawing.Size(338, 161);
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
            this.lblLogFileLocation.Location = new System.Drawing.Point(367, 243);
            this.lblLogFileLocation.Name = "lblLogFileLocation";
            this.lblLogFileLocation.Size = new System.Drawing.Size(88, 13);
            this.lblLogFileLocation.TabIndex = 61;
            this.lblLogFileLocation.Text = "Log File Location";
            // 
            // btnBrowseBackupLocation
            // 
            this.btnBrowseBackupLocation.Location = new System.Drawing.Point(568, 295);
            this.btnBrowseBackupLocation.Name = "btnBrowseBackupLocation";
            this.btnBrowseBackupLocation.Size = new System.Drawing.Size(53, 23);
            this.btnBrowseBackupLocation.TabIndex = 58;
            this.btnBrowseBackupLocation.Text = "Browse";
            this.btnBrowseBackupLocation.UseVisualStyleBackColor = true;
            this.btnBrowseBackupLocation.Click += new System.EventHandler(this.btnBrowseBackupLocation_Click);
            // 
            // lblBackupLocation
            // 
            this.lblBackupLocation.AutoSize = true;
            this.lblBackupLocation.Location = new System.Drawing.Point(367, 283);
            this.lblBackupLocation.Name = "lblBackupLocation";
            this.lblBackupLocation.Size = new System.Drawing.Size(88, 13);
            this.lblBackupLocation.TabIndex = 57;
            this.lblBackupLocation.Text = "Backup Location";
            // 
            // txtboxBackupLocation
            // 
            this.txtboxBackupLocation.Location = new System.Drawing.Point(371, 297);
            this.txtboxBackupLocation.Name = "txtboxBackupLocation";
            this.txtboxBackupLocation.Size = new System.Drawing.Size(194, 20);
            this.txtboxBackupLocation.TabIndex = 56;
            // 
            // txtboxLogFileLocation
            // 
            this.txtboxLogFileLocation.Location = new System.Drawing.Point(370, 256);
            this.txtboxLogFileLocation.Name = "txtboxLogFileLocation";
            this.txtboxLogFileLocation.Size = new System.Drawing.Size(192, 20);
            this.txtboxLogFileLocation.TabIndex = 59;
            // 
            // btnBrowseLogDir
            // 
            this.btnBrowseLogDir.Location = new System.Drawing.Point(566, 253);
            this.btnBrowseLogDir.Name = "btnBrowseLogDir";
            this.btnBrowseLogDir.Size = new System.Drawing.Size(56, 23);
            this.btnBrowseLogDir.TabIndex = 60;
            this.btnBrowseLogDir.Text = "Browse";
            this.btnBrowseLogDir.UseVisualStyleBackColor = true;
            this.btnBrowseLogDir.Click += new System.EventHandler(this.btnBrowseLogDir_Click);
            // 
            // btnDeleteJob
            // 
            this.btnDeleteJob.Location = new System.Drawing.Point(111, 319);
            this.btnDeleteJob.Name = "btnDeleteJob";
            this.btnDeleteJob.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteJob.TabIndex = 59;
            this.btnDeleteJob.Text = "Delete";
            this.btnDeleteJob.UseVisualStyleBackColor = true;
            this.btnDeleteJob.Click += new System.EventHandler(this.btnDeleteJob_Click);
            // 
            // btnNewJob
            // 
            this.btnNewJob.Location = new System.Drawing.Point(192, 320);
            this.btnNewJob.Name = "btnNewJob";
            this.btnNewJob.Size = new System.Drawing.Size(75, 23);
            this.btnNewJob.TabIndex = 60;
            this.btnNewJob.Text = "New";
            this.btnNewJob.UseVisualStyleBackColor = true;
            this.btnNewJob.Click += new System.EventHandler(this.btnNewJob_Click);
            // 
            // BackupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNewJob);
            this.Controls.Add(this.btnDeleteJob);
            this.Controls.Add(this.groupBoxJobDetails);
            this.Controls.Add(this.listBoxJobs);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "BackupPage";
            this.Size = new System.Drawing.Size(925, 396);
            this.Load += new System.EventHandler(this.BackupPage_Load);
            this.groupBoxFolderLocations.ResumeLayout(false);
            this.grpBoxIncremental.ResumeLayout(false);
            this.grpBoxIncremental.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBackupIncremental)).EndInit();
            this.groupBoxJobDetails.ResumeLayout(false);
            this.groupBoxJobDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddSorceLocation;
        private System.Windows.Forms.ListBox listboxSourceLocations;
        private System.Windows.Forms.Label lblIncremental;
        private System.Windows.Forms.GroupBox groupBoxFolderLocations;
        private System.Windows.Forms.CheckBox chkBoxIncremental;
        private System.Windows.Forms.GroupBox grpBoxIncremental;
        private System.Windows.Forms.NumericUpDown numericUpDownBackupIncremental;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewTriggers;
        private System.Windows.Forms.ColumnHeader trigger;
        private System.Windows.Forms.ColumnHeader triggerDetails;
        private System.Windows.Forms.ColumnHeader triggerStatus;
        private System.Windows.Forms.Button btnDeleteTrigger;
        private System.Windows.Forms.Button btnEditTrigger;
        private System.Windows.Forms.Button btnNewTrigger;
    }
}
