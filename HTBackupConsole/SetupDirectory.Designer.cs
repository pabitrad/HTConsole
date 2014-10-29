namespace HTBackupConsole
{
    partial class SetupDirectory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupDirectory));
            this.lblHTbackupInstallDir = new System.Windows.Forms.Label();
            this.txtHTBackupInstallDir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lblHTClusterInstallDir = new System.Windows.Forms.Label();
            this.txtHTClusterInstallDir = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHTbackupInstallDir
            // 
            this.lblHTbackupInstallDir.AutoSize = true;
            this.lblHTbackupInstallDir.Location = new System.Drawing.Point(8, 34);
            this.lblHTbackupInstallDir.Name = "lblHTbackupInstallDir";
            this.lblHTbackupInstallDir.Size = new System.Drawing.Size(137, 13);
            this.lblHTbackupInstallDir.TabIndex = 0;
            this.lblHTbackupInstallDir.Text = "HTBackup Install Directory:";
            // 
            // txtHTBackupInstallDir
            // 
            this.txtHTBackupInstallDir.Location = new System.Drawing.Point(162, 31);
            this.txtHTBackupInstallDir.Name = "txtHTBackupInstallDir";
            this.txtHTBackupInstallDir.Size = new System.Drawing.Size(346, 20);
            this.txtHTBackupInstallDir.TabIndex = 15;
            this.txtHTBackupInstallDir.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(162, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(294, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Directory where HTBackup is installed on the managed servers";
            // 
            // btnUpdate
            // 
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(518, 141);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(605, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(118, 22);
            this.toolStripButton1.Text = "Current Directory";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // lblHTClusterInstallDir
            // 
            this.lblHTClusterInstallDir.AutoSize = true;
            this.lblHTClusterInstallDir.Location = new System.Drawing.Point(8, 86);
            this.lblHTClusterInstallDir.Name = "lblHTClusterInstallDir";
            this.lblHTClusterInstallDir.Size = new System.Drawing.Size(129, 13);
            this.lblHTClusterInstallDir.TabIndex = 18;
            this.lblHTClusterInstallDir.Text = "HTCluster Install Directory";
            // 
            // txtHTClusterInstallDir
            // 
            this.txtHTClusterInstallDir.Location = new System.Drawing.Point(162, 83);
            this.txtHTClusterInstallDir.Name = "txtHTClusterInstallDir";
            this.txtHTClusterInstallDir.Size = new System.Drawing.Size(346, 20);
            this.txtHTClusterInstallDir.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(433, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Directory where HTCluster is installed on the managed servers";
            // 
            // SetupDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 172);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtHTClusterInstallDir);
            this.Controls.Add(this.lblHTClusterInstallDir);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHTBackupInstallDir);
            this.Controls.Add(this.lblHTbackupInstallDir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupDirectory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Directory Setup";
            this.Load += new System.EventHandler(this.SetupDirectory_Load);
            this.Shown += new System.EventHandler(this.SetupDirectory_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHTbackupInstallDir;
        private System.Windows.Forms.TextBox txtHTBackupInstallDir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label lblHTClusterInstallDir;
        private System.Windows.Forms.TextBox txtHTClusterInstallDir;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
    }
}