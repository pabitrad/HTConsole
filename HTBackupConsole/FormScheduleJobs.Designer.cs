namespace HTBackupConsole
{
    partial class FormScheduleJobs
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
            this.grpBoxScheduleJobs = new System.Windows.Forms.GroupBox();
            this.btnRemoveJob = new System.Windows.Forms.Button();
            this.btnAddNewJob = new System.Windows.Forms.Button();
            this.lstBoxScheduleJobs = new System.Windows.Forms.ListBox();
            this.grpBoxScheduleJobs.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxScheduleJobs
            // 
            this.grpBoxScheduleJobs.Controls.Add(this.btnRemoveJob);
            this.grpBoxScheduleJobs.Controls.Add(this.btnAddNewJob);
            this.grpBoxScheduleJobs.Controls.Add(this.lstBoxScheduleJobs);
            this.grpBoxScheduleJobs.Location = new System.Drawing.Point(48, 26);
            this.grpBoxScheduleJobs.Name = "grpBoxScheduleJobs";
            this.grpBoxScheduleJobs.Size = new System.Drawing.Size(188, 211);
            this.grpBoxScheduleJobs.TabIndex = 23;
            this.grpBoxScheduleJobs.TabStop = false;
            this.grpBoxScheduleJobs.Text = "Schedule Jobs";
            // 
            // btnRemoveJob
            // 
            this.btnRemoveJob.Location = new System.Drawing.Point(26, 176);
            this.btnRemoveJob.Name = "btnRemoveJob";
            this.btnRemoveJob.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveJob.TabIndex = 3;
            this.btnRemoveJob.Text = "Remove";
            this.btnRemoveJob.UseVisualStyleBackColor = true;
            // 
            // btnAddNewJob
            // 
            this.btnAddNewJob.Location = new System.Drawing.Point(107, 176);
            this.btnAddNewJob.Name = "btnAddNewJob";
            this.btnAddNewJob.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewJob.TabIndex = 3;
            this.btnAddNewJob.Text = "Add";
            this.btnAddNewJob.UseVisualStyleBackColor = true;
            // 
            // lstBoxScheduleJobs
            // 
            this.lstBoxScheduleJobs.FormattingEnabled = true;
            this.lstBoxScheduleJobs.Location = new System.Drawing.Point(7, 20);
            this.lstBoxScheduleJobs.Name = "lstBoxScheduleJobs";
            this.lstBoxScheduleJobs.Size = new System.Drawing.Size(175, 147);
            this.lstBoxScheduleJobs.TabIndex = 0;
            // 
            // FormScheduleJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.grpBoxScheduleJobs);
            this.Name = "FormScheduleJobs";
            this.Text = "FormScheduleJobs";
            this.grpBoxScheduleJobs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxScheduleJobs;
        private System.Windows.Forms.Button btnRemoveJob;
        private System.Windows.Forms.Button btnAddNewJob;
        private System.Windows.Forms.ListBox lstBoxScheduleJobs;
    }
}