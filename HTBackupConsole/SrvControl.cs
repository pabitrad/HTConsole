using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32.TaskScheduler;
using HTConsoleCommonUtil;
using TaskManagerUtil;

namespace HTBackupConsole
{
    public partial class SrvControl : Form
    {
        private SqlCeConnection cn = new SqlCeConnection(HTConsoleHelper.ConnectionString);

        public SrvControl()
        {
            InitializeComponent();
        }

        private void SrvControl_Shown(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }

            try
            {
                populateServerDropdownlist();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void populateServerDropdownlist()
        {
            SqlCeCommand cmd = new SqlCeCommand("SELECT SERVERNAME FROM SCHEDULER ORDER BY SERVERNAME ASC");
            cmd.Connection = cn;

            SqlCeDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxServer.Items.Add(dr["SERVERNAME"]);
            }

            dr.Close();
            dr.Dispose();
        }

        private void populateJobListview()
        {
            if (string.IsNullOrEmpty(comboBoxServer.Text) == false)
            {
                listViewJob.Items.Clear();
                SqlCeCommand cmd = new SqlCeCommand("SELECT Name, BackupType FROM ScheduleJob WHERE Server = @SERVERNAME");
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@SERVERNAME", comboBoxServer.Text);

                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem listitem = new ListViewItem(dr["Name"].ToString());
                    listitem.SubItems.Add(HTConsoleHelper.getJobType((JOBTYPE)dr["BackupType"]));

                    listViewJob.Items.Add(listitem);
                }
            }
        }

        private void comboBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateJobListview();
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValidate())
                {
                    ListViewItem backupItem = listViewJob.SelectedItems[0];
                    string jobName = backupItem.SubItems[0].Text;
                    //BackupJob job = BackupJobScheduler.getJob(comboBoxServer.Text, jobName);

                    if (TaskManager.isTaskEnabled(comboBoxServer.Text + "-" + jobName.Trim()))
                    {
                        MessageBox.Show("The selected job is already scheduled to start.");
                    }
                    else
                    {
                        BackupJob job = HTConsoleHelper.getSelectedJob(comboBoxServer.Text, jobName);
                        if (job != null)
                        {
                            job.enableTaskTriggers(true);
                            //BackupJobScheduler.addJob(job);

                            MessageBox.Show("The selected job is scheduled successfully to start.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isValidate()
        {
            if (string.IsNullOrEmpty(comboBoxServer.Text))
            {
                MessageBox.Show("Select a server from drop down list.");
                return false;
            }

            if (listViewJob.SelectedItems == null || listViewJob.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a job from job list.");
                return false;
            }

            return true;
        }

        private void btnLogFile_Click(object sender, EventArgs e)
        {
            if (isValidate())
            {
                //TODO : Improve for getSelectedJobLocation()
                ListViewItem backupItem = listViewJob.SelectedItems[0];
                BackupJob job = HTConsoleHelper.getSelectedJob(comboBoxServer.Text, backupItem.SubItems[0].Text);
                if (job != null)
                {
                    string logFileName = string.Empty;
                    switch (job.BackupType)
                    {
                        case ServerBackupType.ServerBackup:
                        case ServerBackupType.EssbaseBackup:
                            if (job.JobType == JOBTYPE.FULLBACKUP)
                            {
                                logFileName = job.LogFileLocation + "\\HTBaseFullBackup.log";
                            }
                            else if (job.JobType == JOBTYPE.INCREMENTAL)
                            {
                                logFileName = job.LogFileLocation + "\\HTBaseIncrementalBackup.log";
                            }                            
                            break;

                        case ServerBackupType.Cluster:
                            if (job.JobType == JOBTYPE.FULLBACKUP)
                            {
                                logFileName = job.LogFileLocation + "\\HTClusterFullReplication.log";
                            }
                            else if (job.JobType == JOBTYPE.INCREMENTAL)
                            {
                                logFileName = job.LogFileLocation + "\\HTClusterIncrementalReplication.log";
                            }                            
                            break;

                        default:
                            break;
                    }

                    Process.Start("notepad.exe", logFileName);
                }
            }
        }

        //private BackupJob getSelectedJob(string serverName, string jobName)
        //{
        //    SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM ScheduleJob WHERE Server = @ServerName AND Name = @JobName");
        //    cmd.Connection = cn;
        //    cmd.Parameters.AddWithValue("@ServerName", serverName);
        //    cmd.Parameters.AddWithValue("@JobName", jobName);

        //    SqlCeDataReader dr = cmd.ExecuteReader();
        //    BackupJob job = null;
        //    if (dr.Read())
        //    {
        //        job = new BackupJob();
        //        job.Name = dr["Name"].ToString();
        //        job.Server = dr["Server"].ToString();
        //        job.JobType = (JOBTYPE)(dr["BackupType"]);
        //        job.ScheduleType = (SCHEDULETYPE)(dr["ScheduleType"]);
        //        job.StartDate = Convert.ToDateTime(dr["StartDate"]);
        //        job.StartTime = TimeSpan.Parse(dr["StartTime"].ToString());
        //        job.IncrementInterval = Convert.ToInt32(dr["IncrementInterval"]);
        //        job.BackupLocation = dr["BackupLocation"].ToString();
        //        job.LogFileLocation = dr["LogDirLocation"].ToString();
        //        job.SourceLocations = getSourceLocations(dr["SourceLocation"].ToString());
        //    }

        //    return job;
        //}

        private void btnStopService_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValidate())
                {
                    ListViewItem backupItem = listViewJob.SelectedItems[0];
                    string jobName = backupItem.SubItems[0].Text;

                    //BackupJob job = BackupJobScheduler.getJob(comboBoxServer.Text, jobName);
                    if (TaskManager.isTaskEnabled(comboBoxServer.Text + "-" + jobName.Trim()))
                    //if (job != null)
                    {
                        BackupJob job = HTConsoleHelper.getSelectedJob(comboBoxServer.Text, jobName);

                        SecurityOptions securityOption = new SecurityOptions();
                        securityOption.RunAsUser = job.RunAsUser;
                        securityOption.Password = job.Password;
                        securityOption.HighestPrivilege = job.HighestPrivilege;
                        securityOption.StorePassword = job.StorePassword;

                        TaskManager.enableTriggers(comboBoxServer.Text + "-" + jobName.Trim(), securityOption, false);
                        //job.enableTaskTriggers(false);
                        //BackupJobScheduler.removeJob(job);
                        //job.stopTimer();
                        MessageBox.Show("The selected job is stopped successfully.");
                    }
                    else
                    {
                        MessageBox.Show("The selected job is not yet started.");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}