using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Configuration;
using System.Collections;
using System.Globalization;
using Microsoft.Win32.TaskScheduler;
using HTConsoleCommonUtil;

namespace HTBackupUserControl
{
    public partial class BackupPage: UserControl
    {
        ServerBackupType _serverBackupType = ServerBackupType.ServerBackup;
        JOBTYPE _jobType = JOBTYPE.FULLBACKUP;
        ArrayList _backupJobs = null;

        public BackupPage()
        {
            InitializeComponent();
        }

        public void setServerBackupType(ServerBackupType serverBackupType)
        {
            _serverBackupType = serverBackupType;

            if (_serverBackupType == ServerBackupType.EssbaseBackup)
            {
                groupBoxFolderLocations.Text = "Application Locations";
            }
            else if (_serverBackupType == ServerBackupType.Cluster)
            {
                groupBoxFolderLocations.Text = "Application Locations";
                lblBackupLocation.Text = "Replication Locations";
                grpBoxIncremental.Text = "Replication Type";
            }
        }

        public void setRunningJobs(ArrayList runningJobs)
        {
            _backupJobs = runningJobs;
        }

        private void initializeControls()
        {
            List<string> listServers = HTConsoleHelper.getServers();
            if (listServers.Count > 0)
            {
                cmbBoxServer.DataSource = listServers;
            }
        }

        private void btnBrowseBackupLocation_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtboxBackupLocation.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnBrowseLogDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtboxLogFileLocation.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                listboxSourceLocations.Items.Add(folderBrowserDialog.SelectedPath);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listboxSourceLocations.SelectedIndex >=0 )
            {
                listboxSourceLocations.Items.RemoveAt(listboxSourceLocations.SelectedIndex);
            }
        }

        private void chkBoxIncremental_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox incremental = sender as CheckBox;
            if (incremental != null)
            {
                lblIncremental.Enabled = incremental.Checked;
                numericUpDownBackupIncremental.Enabled = incremental.Checked;

                if (incremental.Checked)
                {
                    _jobType = JOBTYPE.INCREMENTAL;
                }
                else
                {
                    _jobType = JOBTYPE.FULLBACKUP;
                }
            }
        }

        private bool isValidate()
        {
            if (cmbBoxServer.SelectedIndex == 0)
            {
                MessageBox.Show("Select a server from drop down list.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtJobName.Text))
            {
                MessageBox.Show("Job Name can not be empty.");
                txtJobName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtboxLogFileLocation.Text))
            {
                MessageBox.Show("Log File location can not be empty.");
                txtboxLogFileLocation.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtboxBackupLocation.Text))
            {
                if (_serverBackupType == ServerBackupType.Cluster)
                {
                    MessageBox.Show("Replication locations can not be empty.");
                }
                else
                {
                    MessageBox.Show("Backup location can not be empty.");
                }

                txtboxBackupLocation.Focus();
                return false;
            }

            if (listboxSourceLocations.Items.Count == 0)
            {
                if (_serverBackupType == ServerBackupType.ServerBackup)
                {
                    MessageBox.Show("Folder locations can not be empty.");
                    listboxSourceLocations.Focus();
                    return false;
                }
                else
                {
                    //getEssAppDirectory
                }
            }

            if (listViewTriggers.Items.Count == 0)
            {
                MessageBox.Show("Trigger list can not be empty.");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValidate())
                {
                    if (isJobAlreadyExits())
                    {
                        modifyJob();
                    }
                    else
                    {
                        insertJob();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isJobAlreadyExits()
        {
            return listBoxJobs.FindItemWithText(txtJobName.Text.Trim()) != null;
        }

        private void modifyJob()
        {
            string selectedNode = cmbBoxServer.Text;

            string logFileLocation = txtboxLogFileLocation.Text;
            string backupLocation = txtboxBackupLocation.Text;
            string sourceLocations = getSourceLocations(listboxSourceLocations);
            int incrementalInterval = (_jobType == JOBTYPE.INCREMENTAL) ? (int)numericUpDownBackupIncremental.Value : 0;

            string sqlString = @"UPDATE ScheduleJob SET BackupType = @BackupType, SourceLocation = @SourceLocation, BackupLocation = @BackupLocation,
                                                        LogDirLocation = @LogDirLocation, IncrementInterval = @IncrementInterval
                                                        WHERE Name = @JobName and Server = @NodeName";

            SqlCeCommand sqlCommand = new SqlCeCommand(sqlString);
            sqlCommand.Connection = new SqlCeConnection(HTConsoleHelper.ConnectionString);
            sqlCommand.Connection.Open();

            sqlCommand.Parameters.AddWithValue("@JobName", txtJobName.Text);
            sqlCommand.Parameters.AddWithValue("@NodeName", selectedNode);
            sqlCommand.Parameters.AddWithValue("@BackupType", _jobType);
            sqlCommand.Parameters.AddWithValue("@SourceLocation", sourceLocations);
            sqlCommand.Parameters.AddWithValue("@BackupLocation", backupLocation);
            sqlCommand.Parameters.AddWithValue("@LogDirLocation", logFileLocation);
            sqlCommand.Parameters.AddWithValue("@IncrementInterval", incrementalInterval);

            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                modifyTask();
                MessageBox.Show("Job updated successfully.");
            }
        }

        private void insertJob()
        {
            string selectedNode = cmbBoxServer.Text;
            string logFileLocation = txtboxLogFileLocation.Text;
            string backupLocation = txtboxBackupLocation.Text;
            string sourceLocations = getSourceLocations(listboxSourceLocations);
            int incrementalInterval = (_jobType == JOBTYPE.INCREMENTAL) ? (int)numericUpDownBackupIncremental.Value : 0;

            string sqlString = @"INSERT INTO ScheduleJob VALUES 
                                (@Name, @Server, @BackupType, @SourceLocation, @BackupLocation, @LogDirLocation, @IncrementInterval, @ServerBackupType)";

            SqlCeCommand sqlCommand = new SqlCeCommand(sqlString);
            sqlCommand.Connection = new SqlCeConnection(HTConsoleHelper.ConnectionString);
            sqlCommand.Connection.Open();

            sqlCommand.Parameters.AddWithValue("@Name", txtJobName.Text);
            sqlCommand.Parameters.AddWithValue("@Server", selectedNode);
            sqlCommand.Parameters.AddWithValue("@BackupType", _jobType);
            sqlCommand.Parameters.AddWithValue("@SourceLocation", sourceLocations);
            sqlCommand.Parameters.AddWithValue("@BackupLocation", backupLocation);
            sqlCommand.Parameters.AddWithValue("@LogDirLocation", logFileLocation);
            sqlCommand.Parameters.AddWithValue("@IncrementInterval", incrementalInterval);
            sqlCommand.Parameters.AddWithValue("@ServerBackupType", _serverBackupType);

            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                BackupJob job = addJobToListview();
                createTask(job);
                MessageBox.Show("Job saved successfully.");
                reset();
            }

            sqlCommand.Connection.Close();
        }

        private void createTask(BackupJob job)
        {
            List<Trigger> triggers = getTriggers();
            List<Microsoft.Win32.TaskScheduler.Action> actions = getActions(job);
            
            string taskName = cmbBoxServer.Text.Trim() + "-" + txtJobName.Text.Trim();

            TaskManager.createTask(taskName, triggers, actions);
        }

        private void modifyTask()
        {
            List<Trigger> triggers = getTriggers();
            List<Microsoft.Win32.TaskScheduler.Action> actions = getActions(getSelectedJob());

            string taskName = cmbBoxServer.Text.Trim() + "-" + txtJobName.Text.Trim();

            TaskManager.modifyTask(taskName, triggers, actions);
        }

        private List<Trigger> getTriggers()
        {
            List<Trigger> triggerList = new List<Trigger>();

            foreach (ListViewItem item in listViewTriggers.Items)
            {
                Trigger trigger = item.Tag as Trigger;
                if (trigger != null)
                {
                    triggerList.Add((Trigger)trigger.Clone());
                }
            }

            return triggerList;
        }

        private List<Microsoft.Win32.TaskScheduler.Action> getActions(BackupJob job)
        {
            if (job != null)
            {
                return job.getActions();
            }

            return null;
        }

        private BackupJob getSelectedJob()
        {
            if (listBoxJobs.SelectedItems != null && listBoxJobs.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listBoxJobs.SelectedItems[0];
                BackupJob job = selectedItem.Tag as BackupJob;

                return job;
            }

            return null;
        }

        private BackupJob addJobToListview()
        {
            ListViewItem listitem = new ListViewItem(txtJobName.Text);
            listitem.SubItems.Add(HTConsoleHelper.getJobType(_jobType));

            listitem = listBoxJobs.Items.Add(listitem);
            BackupJob job = HTConsoleHelper.getSelectedJob(cmbBoxServer.Text.Trim(), txtJobName.Text.Trim());
            if (job != null)
            {
                listitem.Tag = job;
            }

            return job;
        }

        private string getSourceLocations(ListBox listBox)
        {
            string sourceLocations = string.Empty;
            if (listBox.Items.Count == 0 && (_serverBackupType == ServerBackupType.EssbaseBackup || _serverBackupType == ServerBackupType.Cluster))
            {
                sourceLocations = HTConsoleHelper.getEssAppDirectory();
            }
            else
            {
                foreach (Object item in listBox.Items)
                {
                    sourceLocations += item.ToString() + "|";
                }
            }

            return sourceLocations;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to reset all values?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                reset();
            }
        }

        private void reset()
        {
            //TODO:During edit mode reset it previous values
            txtJobName.Text = string.Empty;
            chkBoxIncremental.Checked = false;
            numericUpDownBackupIncremental.Value = 30;
            txtboxLogFileLocation.Text = string.Empty;
            txtboxBackupLocation.Text = string.Empty;
            listboxSourceLocations.Items.Clear();
            listViewTriggers.Items.Clear();
        }

        private void BackupPage_Load(object sender, EventArgs e)
        {
            initializeControls();
        }

        private void populateJobListview()
        {
            if (string.IsNullOrEmpty(cmbBoxServer.Text) == false)
            {
                listBoxJobs.Items.Clear();
                SqlCeCommand cmd = new SqlCeCommand("SELECT Name, BackupType FROM ScheduleJob WHERE Server = @SERVERNAME  AND ServerBackupType = @SERVERBACKUPTYPE");
                SqlCeConnection sqlConnection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString());
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@SERVERNAME", cmbBoxServer.Text);
                cmd.Parameters.AddWithValue("@SERVERBACKUPTYPE", _serverBackupType);

                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem listitem = new ListViewItem(dr["Name"].ToString());
                    listitem.SubItems.Add(HTConsoleHelper.getJobType((JOBTYPE)dr["BackupType"]));

                    listBoxJobs.Items.Add(listitem);
                }
            }
        }

        private void cmbBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBoxServer.SelectedIndex > 0)
                {
                    populateJobListview();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewJob_Click(object sender, EventArgs e)
        {
            createBlankJob();
        }

        private void createBlankJob()
        {
            txtJobName.Text = string.Empty;
            chkBoxIncremental.Checked = false;
            numericUpDownBackupIncremental.Value = 30;
            txtboxLogFileLocation.Text = string.Empty;
            txtboxBackupLocation.Text = string.Empty;
            listboxSourceLocations.Items.Clear();
            listViewTriggers.Items.Clear();

            groupBoxJobDetails.Enabled = true;
            txtJobName.Enabled = true;
        }

        private void btnDeleteJob_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxJobs.SelectedIndices != null && listBoxJobs.SelectedIndices.Count > 0)
                {
                    string serverName = cmbBoxServer.Text;
                    int selectedIndex = listBoxJobs.SelectedIndices[0];
                    ListViewItem item = listBoxJobs.Items[selectedIndex];
                    string jobName = item.SubItems[0].Text;

                    if (isJobRunning(serverName, jobName))
                    {
                        MessageBox.Show("The selected job can not be deleted because it is already running or already scheduled to start.");
                        return;
                    }

                    if (MessageBox.Show("Would you like to delete selected backup job?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SqlCeCommand cmd = new SqlCeCommand("DELETE FROM ScheduleJob WHERE Server = @Servername AND Name = @JobName");
                        cmd.Parameters.AddWithValue("@ServerName", serverName);
                        cmd.Parameters.AddWithValue("@JobName", jobName);

                        SqlCeConnection sqlConnection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString());
                        cmd.Connection = sqlConnection;
                        sqlConnection.Open();

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            listBoxJobs.Items.RemoveAt(selectedIndex);
                            TaskManager.deleteTask(serverName + "-" + jobName);

                            createBlankJob();
                        }
                        else
                        {
                            MessageBox.Show("Job could not be deleted from database.");
                        }

                        sqlConnection.Close();
                        cmd.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Select a backup job from list to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxJobs.SelectedItems != null && listBoxJobs.SelectedItems.Count > 0)
                {
                    ListViewItem item = listBoxJobs.SelectedItems[0];
                    BackupJob job = null;
                    if (item.Tag == null)
                    {
                        string jobName = item.SubItems[0].Text;
                        string serverName = cmbBoxServer.Text;

                        job = HTConsoleHelper.getSelectedJob(serverName, jobName);
                        if (job != null)
                        {
                            item.Tag = job;
                        }
                    }
                    else
                    {
                        job = (BackupJob) item.Tag;
                    }
                    setJobDetails(job);
                    readTriggers(job);

                    groupBoxJobDetails.Enabled =  !(isJobRunning(job.Server, job.Name)); // Disable the tab if job is already running or scheduled to start.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isJobRunning(string serverName, string jobName)
        {
            return _backupJobs != null && _backupJobs.Contains(serverName + "-" + jobName);
        }

        private void setJobDetails(BackupJob job)
        {
            txtJobName.Text = job.Name;
            _jobType = job.JobType;
            chkBoxIncremental.Checked = (job.JobType == JOBTYPE.INCREMENTAL);
            numericUpDownBackupIncremental.Value = job.IncrementInterval;
            txtboxLogFileLocation.Text = job.LogFileLocation;
            txtboxBackupLocation.Text = job.BackupLocation;
            listboxSourceLocations.Items.Clear();
            listboxSourceLocations.Items.AddRange(job.SourceLocations.ToArray());
            txtJobName.Enabled = false;
        }

        private void readTriggers(BackupJob job)
        {
            listViewTriggers.Items.Clear();
            string taskName = job.Server + "-" + job.Name;
            TriggerCollection triggers = TaskManager.getTriggers(taskName);

            if (triggers != null && triggers.Count > 0)
            {
                foreach (Trigger trigger in triggers)
                {
                    addTriggerToList(trigger);
                }
            }
        }

        private void btnNewTrigger_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                TriggerEditDialog triggerDlg = new TriggerEditDialog();
                if (triggerDlg.ShowDialog() == DialogResult.OK)
                {
                    Trigger trigger = triggerDlg.Trigger;
                    trigger.Enabled = false;
                    addTriggerToList(trigger);
                }
                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditTrigger_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewTriggers.SelectedItems != null && listViewTriggers.SelectedItems.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ListViewItem item = listViewTriggers.SelectedItems[0];
                    TriggerEditDialog triggerDlg = new TriggerEditDialog(item.Tag as Trigger, false);

                    if (triggerDlg.ShowDialog() == DialogResult.OK)
                    {
                        updateTrigger(triggerDlg.Trigger, item);
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Select a trigger from list to edit.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addTriggerToList(Trigger newTrigger)
        {
            ListViewItem listitem = new ListViewItem(newTrigger.TriggerType.ToString());
            listitem.SubItems.Add(newTrigger.ToString());
            listitem.SubItems.Add(newTrigger.Enabled ? "Enabled" : "Disabled");
            listitem.Tag = newTrigger;

            listViewTriggers.Items.Add(listitem);
        }

        private void updateTrigger(Trigger trigger, ListViewItem item)
        {
            item.SubItems[0].Text = trigger.TriggerType.ToString();
            item.SubItems[1].Text = trigger.ToString();
            item.SubItems[2].Text = trigger.Enabled ? "Enabled" : "Disabled";

            item.Tag = trigger;
        }

        private void btnDeleteTrigger_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewTriggers.SelectedItems != null && listViewTriggers.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Would you like to delete selected trigger?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        listViewTriggers.Items.RemoveAt(listViewTriggers.SelectedIndices[0]);
                        //TODO:Delete entry from trigger database.
                    }
                }
                else
                {
                    MessageBox.Show("Select a trigger from list to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listViewTriggers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView triggerView = sender as ListView;
            if (triggerView != null)
            {
                btnEditTrigger_Click(null, null);
            }
        }
    }
}