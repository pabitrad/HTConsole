namespace HTBackupConsole
{
    partial class SrvControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SrvControl));
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewJob = new System.Windows.Forms.ListView();
            this.jobName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backupType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hTBackupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLogFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hTBackupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Location = new System.Drawing.Point(149, 17);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(147, 21);
            this.comboBoxServer.TabIndex = 2;
            this.comboBoxServer.SelectedIndexChanged += new System.EventHandler(this.comboBoxServer_SelectedIndexChanged);
            // 
            // btnStartService
            // 
            this.btnStartService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartService.Location = new System.Drawing.Point(249, 280);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(75, 23);
            this.btnStartService.TabIndex = 3;
            this.btnStartService.Text = "Start";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopService.Location = new System.Drawing.Point(60, 280);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(75, 23);
            this.btnStopService.TabIndex = 4;
            this.btnStopService.Text = "Stop";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Server:";
            // 
            // listViewJob
            // 
            this.listViewJob.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.jobName,
            this.backupType});
            this.listViewJob.FullRowSelect = true;
            this.listViewJob.HideSelection = false;
            this.listViewJob.Location = new System.Drawing.Point(12, 66);
            this.listViewJob.MultiSelect = false;
            this.listViewJob.Name = "listViewJob";
            this.listViewJob.ShowGroups = false;
            this.listViewJob.Size = new System.Drawing.Size(312, 196);
            this.listViewJob.TabIndex = 5;
            this.listViewJob.UseCompatibleStateImageBehavior = false;
            this.listViewJob.View = System.Windows.Forms.View.Details;
            // 
            // jobName
            // 
            this.jobName.Text = "Job Name";
            this.jobName.Width = 200;
            // 
            // backupType
            // 
            this.backupType.Text = "Backup Type";
            this.backupType.Width = 90;
            // 
            // hTBackupBindingSource
            // 
            this.hTBackupBindingSource.DataSource = typeof(HTBackupConsole.HTBackup);
            // 
            // btnLogFile
            // 
            this.btnLogFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogFile.Location = new System.Drawing.Point(141, 280);
            this.btnLogFile.Name = "btnLogFile";
            this.btnLogFile.Size = new System.Drawing.Size(102, 23);
            this.btnLogFile.TabIndex = 6;
            this.btnLogFile.Text = "Read Log File";
            this.btnLogFile.UseVisualStyleBackColor = true;
            this.btnLogFile.Click += new System.EventHandler(this.btnLogFile_Click);
            // 
            // SrvControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 317);
            this.Controls.Add(this.btnLogFile);
            this.Controls.Add(this.listViewJob);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.comboBoxServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SrvControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Control";
            this.Shown += new System.EventHandler(this.SrvControl_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.hTBackupBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxServer;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewJob;
        private System.Windows.Forms.BindingSource hTBackupBindingSource;
        private System.Windows.Forms.ColumnHeader jobName;
        private System.Windows.Forms.ColumnHeader backupType;
        private System.Windows.Forms.Button btnLogFile;


    }
}