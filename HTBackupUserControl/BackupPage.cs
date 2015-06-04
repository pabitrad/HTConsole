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
using System.Reflection;
using System.DirectoryServices.AccountManagement;

using Microsoft.Win32.TaskScheduler;
using HTConsoleCommonUtil;
using TaskManagerUtil;
using FolderSelect;

namespace HTBackupUserControl
{
    public partial class BackupPage: UserControl
    {
        ServerBackupType _serverBackupType = ServerBackupType.ServerBackup;
        JOBTYPE _jobType = JOBTYPE.FULLBACKUP;
        string _selectedServer = string.Empty;

        FolderSelectDialog _fsdSourceLocation = new FolderSelectDialog();
        FolderSelectDialog _fsdLogLocation = new FolderSelectDialog();
        FolderSelectDialog _fsdBackupLocation = new FolderSelectDialog();

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

        public void setSelectedServer(string server)
        {
            if (string.IsNullOrWhiteSpace(server))
            {
                return;
            }
            _selectedServer = server.Trim();
            _fsdSourceLocation.InitialDirectory = @"\\" + _selectedServer;
            _fsdLogLocation.InitialDirectory = @"\\" + _selectedServer;
            _fsdBackupLocation.InitialDirectory = @"\\" + _selectedServer;

            populateJobListview();
        }

        private void btnBrowseBackupLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtboxBackupLocation.Text) == false)
                {
                    _fsdBackupLocation.InitialDirectory = txtboxBackupLocation.Text.Trim();
                }

                if (_fsdBackupLocation.ShowDialog())
                {
                    txtboxBackupLocation.Text = _fsdBackupLocation.FileName;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowseLogDir_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtboxLogFileLocation.Text) == false)
                {
                    _fsdLogLocation.InitialDirectory = txtboxLogFileLocation.Text.Trim();
                }
                if (_fsdLogLocation.ShowDialog())
                {
                    txtboxLogFileLocation.Text = _fsdLogLocation.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_fsdSourceLocation.ShowDialog())
                {
                    listboxSourceLocations.Items.Add(_fsdSourceLocation.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (listboxSourceLocations.SelectedIndex >= 0)
                {
                    listboxSourceLocations.Items.RemoveAt(listboxSourceLocations.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkBoxIncremental_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox incremental = sender as CheckBox;
                if (incremental != null)
                {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isValidate()
        {
            if (string.IsNullOrWhiteSpace(_selectedServer))
            {
                MessageBox.Show("Selecte a server.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRunAsUser.Text))
            {
                MessageBox.Show("Username can not be empty.");
                txtRunAsUser.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password can not be empty.");
                txtPassword.Focus();
                return false;
            }

            if (isAuthenticate() == false)
            {
                MessageBox.Show("Invalid username or password.");
                txtRunAsUser.Focus();
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
                Cursor.Current = Cursors.WaitCursor;
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
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool isJobAlreadyExits()
        {
            return listBoxJobs.FindItemWithText(txtJobName.Text.Trim()) != null;
        }

        private void modifyJob()
        {
            string logFileLocation = txtboxLogFileLocation.Text;
            string backupLocation = txtboxBackupLocation.Text;
            string sourceLocations = getSourceLocations(listboxSourceLocations);
            string runAsUser = txtRunAsUser.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool highestPrivilege = chkHighestPrivilege.Checked;
            bool storePassword = chkStorePassword.Checked;

            string sqlString = @"UPDATE ScheduleJob SET BackupType = @BackupType, SourceLocation = @SourceLocation, BackupLocation = @BackupLocation,
                                                        LogDirLocation = @LogDirLocation, RunAsUser = @RunAsUser, Password = @Password, 
                                                        HighestPrivilege = @HighestPrivilege, StorePassword = @StorePassword
                                                        WHERE Name = @JobName and Server = @NodeName";
            
            //BackupRetension = @BackupRetension, Compress = @Compress
            SqlCeCommand sqlCommand = new SqlCeCommand(sqlString);
            sqlCommand.Connection = new SqlCeConnection(HTConsoleHelper.ConnectionString);
            sqlCommand.Connection.Open();

            sqlCommand.Parameters.AddWithValue("@JobName", txtJobName.Text);
            sqlCommand.Parameters.AddWithValue("@NodeName", _selectedServer);
            sqlCommand.Parameters.AddWithValue("@BackupType", _jobType);
            sqlCommand.Parameters.AddWithValue("@SourceLocation", sourceLocations);
            sqlCommand.Parameters.AddWithValue("@BackupLocation", backupLocation);
            sqlCommand.Parameters.AddWithValue("@LogDirLocation", logFileLocation);
            //sqlCommand.Parameters.AddWithValue("@IncrementInterval", 0); // Not used now
            sqlCommand.Parameters.AddWithValue("@RunAsUser", runAsUser);
            sqlCommand.Parameters.AddWithValue("@Password", password);
            sqlCommand.Parameters.AddWithValue("@HighestPrivilege", highestPrivilege);
            sqlCommand.Parameters.AddWithValue("@StorePassword", storePassword);
            //sqlCommand.Parameters.AddWithValue("@BackupRetension", DBNull.Value);
            //sqlCommand.Parameters.AddWithValue("@Compress", DBNull.Value);

            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                BackupJob job = getSelectedJob();
                if (job != null)
                {
                    job.LogFileLocation = logFileLocation;
                    job.BackupLocation = backupLocation;
                    job.SourceLocations = HTConsoleHelper.getSourceLocations(sourceLocations);
                    //job.IncrementInterval = incrementalInterval;
                    job.JobType = _jobType;
                    job.RunAsUser = runAsUser;
                    job.Password = password;
                    job.HighestPrivilege = highestPrivilege;
                    job.StorePassword = storePassword;
                }

                modifyTask();
                MessageBox.Show("Job updated successfully.");
            }
        }

        private void insertJob()
        {
            string jobName = txtJobName.Text.Trim();
            string logFileLocation = txtboxLogFileLocation.Text;
            string backupLocation = txtboxBackupLocation.Text;
            string sourceLocations = getSourceLocations(listboxSourceLocations);
            string runAsUser = txtRunAsUser.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool highestPrivilege = chkHighestPrivilege.Checked;
            bool storePassword = chkStorePassword.Checked;
            //int incrementalInterval = (_jobType == JOBTYPE.INCREMENTAL) ? (int)numericUpDownBackupIncremental.Value : 0;

            string sqlString = @"INSERT INTO ScheduleJob VALUES 
                                (@Name, @Server, @BackupType, @SourceLocation, @BackupLocation, @LogDirLocation, @ServerBackupType,
                                 @RunAsUser, @Password, @HighestPrivilege, @StorePassword, @Compress, @BackupRetension)";

            SqlCeCommand sqlCommand = new SqlCeCommand(sqlString);
            sqlCommand.Connection = new SqlCeConnection(HTConsoleHelper.ConnectionString);
            sqlCommand.Connection.Open();

            sqlCommand.Parameters.AddWithValue("@Name", jobName);
            sqlCommand.Parameters.AddWithValue("@Server", _selectedServer);
            sqlCommand.Parameters.AddWithValue("@BackupType", _jobType);
            sqlCommand.Parameters.AddWithValue("@SourceLocation", sourceLocations);
            sqlCommand.Parameters.AddWithValue("@BackupLocation", backupLocation);
            sqlCommand.Parameters.AddWithValue("@LogDirLocation", logFileLocation);
            //sqlCommand.Parameters.AddWithValue("@IncrementInterval", 0);// Not used now.
            sqlCommand.Parameters.AddWithValue("@ServerBackupType", _serverBackupType);
            sqlCommand.Parameters.AddWithValue("@RunAsUser", runAsUser);
            sqlCommand.Parameters.AddWithValue("@Password", password);
            sqlCommand.Parameters.AddWithValue("@HighestPrivilege", highestPrivilege);
            sqlCommand.Parameters.AddWithValue("@StorePassword", storePassword);
            sqlCommand.Parameters.AddWithValue("@BackupRetension", DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@Compress", DBNull.Value);

            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                BackupJob job = addJobToListview();
                createTask(job);
                MessageBox.Show("Job saved successfully.");
                selectJob(jobName); // select job in list view
                //reset();
            }

            sqlCommand.Connection.Close();
        }

        private void createTask(BackupJob job)
        {
            List<Trigger> triggers = getTriggers();
            List<Microsoft.Win32.TaskScheduler.Action> actions = getActions(job);
            
            string taskName = _selectedServer + "-" + txtJobName.Text.Trim();

            SecurityOptions securityOption = new SecurityOptions();
            securityOption.RunAsUser = job.RunAsUser;
            securityOption.Password = job.Password;
            securityOption.HighestPrivilege = job.HighestPrivilege;
            securityOption.StorePassword = job.StorePassword;

            TaskManager.createTask(_selectedServer, taskName, securityOption, triggers, actions);
        }

        private void modifyTask()
        {
            List<Trigger> triggers = getTriggers();
            BackupJob job = getSelectedJob();
            List<Microsoft.Win32.TaskScheduler.Action> actions = getActions(job);

            string taskName = _selectedServer + "-" + txtJobName.Text.Trim();

            SecurityOptions securityOption = new SecurityOptions();
            securityOption.RunAsUser = job.RunAsUser;
            securityOption.Password = job.Password;
            securityOption.HighestPrivilege = job.HighestPrivilege;
            securityOption.StorePassword = job.StorePassword;

            TaskManager.modifyTask(_selectedServer, taskName, securityOption, triggers, actions);
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
            ListViewItem selectedItem = listBoxJobs.FindItemWithText(txtJobName.Text.Trim());
            if (selectedItem != null)
            {
                BackupJob job = selectedItem.Tag as BackupJob;

                return job;
            }

            return null;
        }

        private void selectJob(string jobName)
        {
            ListViewItem selectedItem = listBoxJobs.FindItemWithText(jobName);
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
            }
        }

        private BackupJob addJobToListview()
        {
            ListViewItem listitem = new ListViewItem(txtJobName.Text);
            listitem.SubItems.Add(HTConsoleHelper.getJobType(_jobType));

            listitem = listBoxJobs.Items.Add(listitem);
            //listitem.Selected = true;
            BackupJob job = HTConsoleHelper.getSelectedJob(_selectedServer, txtJobName.Text.Trim());
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
            BackupJob job = getSelectedJob();
            if (job != null)
            {
                txtJobName.Text = job.Name;
                chkBoxIncremental.Checked = (job.JobType == JOBTYPE.INCREMENTAL);
                //numericUpDownBackupIncremental.Value = job.IncrementInterval;
                txtboxLogFileLocation.Text = job.LogFileLocation;
                txtboxBackupLocation.Text = job.BackupLocation;
                listboxSourceLocations.Items.Clear();
                listboxSourceLocations.Items.AddRange(job.SourceLocations.ToArray());
                readTriggers(job);

                txtRunAsUser.Text = job.RunAsUser;
                txtPassword.Text = job.Password;
                chkHighestPrivilege.Checked = job.HighestPrivilege;
                chkStorePassword.Checked = job.StorePassword;
            }
            else
            {
                txtJobName.Text = string.Empty;
                chkBoxIncremental.Checked = false;
                //numericUpDownBackupIncremental.Value = 30;
                txtboxLogFileLocation.Text = string.Empty;
                txtboxBackupLocation.Text = string.Empty;
                listboxSourceLocations.Items.Clear();
                listViewTriggers.Items.Clear();

                txtRunAsUser.Text = string.Empty;
                txtPassword.Text = string.Empty;
                chkHighestPrivilege.Checked = true;
                chkStorePassword.Checked = false;
            }
        }

        private void BackupPage_Load(object sender, EventArgs e)
        {
        }

        private void populateJobListview()
        {
            if (string.IsNullOrEmpty(_selectedServer) == false)
            {
                listBoxJobs.Items.Clear();
                SqlCeCommand cmd = new SqlCeCommand("SELECT Name, BackupType FROM ScheduleJob WHERE Server = @SERVERNAME  AND ServerBackupType = @SERVERBACKUPTYPE");
                SqlCeConnection sqlConnection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString());
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@SERVERNAME", _selectedServer);
                cmd.Parameters.AddWithValue("@SERVERBACKUPTYPE", _serverBackupType);

                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem listitem = new ListViewItem(dr["Name"].ToString());

                    listBoxJobs.Items.Add(listitem);
                }

                if (txtJobName.Enabled == false)
                {
                    createBlankJob();
                }
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
            //numericUpDownBackupIncremental.Value = 30;
            txtboxLogFileLocation.Text = string.Empty;
            txtboxBackupLocation.Text = string.Empty;
            listboxSourceLocations.Items.Clear();
            listViewTriggers.Items.Clear();

            txtRunAsUser.Text = string.Empty;
            txtPassword.Text = string.Empty;
            chkHighestPrivilege.Checked = true;
            chkStorePassword.Checked = false;

            groupBoxJobDetails.Enabled = true;
            txtJobName.Enabled = true;

            ActiveControl = txtJobName;
        }

        private void btnDeleteJob_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxJobs.SelectedIndices != null && listBoxJobs.SelectedIndices.Count > 0)
                {
                    int selectedIndex = listBoxJobs.SelectedIndices[0];
                    ListViewItem item = listBoxJobs.Items[selectedIndex];
                    string jobName = item.SubItems[0].Text;

                    if (MessageBox.Show("Would you like to delete selected backup job?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SqlCeCommand cmd = new SqlCeCommand("DELETE FROM ScheduleJob WHERE Server = @Servername AND Name = @JobName");
                        cmd.Parameters.AddWithValue("@ServerName", _selectedServer);
                        cmd.Parameters.AddWithValue("@JobName", jobName);

                        SqlCeConnection sqlConnection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString());
                        cmd.Connection = sqlConnection;
                        sqlConnection.Open();

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            BackupJob job = getSelectedJob();

                            SecurityOptions securityOption = new SecurityOptions();
                            securityOption.RunAsUser = job.RunAsUser;
                            securityOption.Password = job.Password;
                            securityOption.HighestPrivilege = job.HighestPrivilege;
                            securityOption.StorePassword = job.StorePassword;

                            listBoxJobs.Items.RemoveAt(selectedIndex);
                            TaskManager.deleteTask(_selectedServer, _selectedServer + "-" + jobName, securityOption);

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

                        job = HTConsoleHelper.getSelectedJob(_selectedServer, jobName);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setJobDetails(BackupJob job)
        {
            txtJobName.Text = job.Name;
            _jobType = job.JobType;
            chkBoxIncremental.Checked = (job.JobType == JOBTYPE.INCREMENTAL);
            //numericUpDownBackupIncremental.Value = job.IncrementInterval;
            txtboxLogFileLocation.Text = job.LogFileLocation;
            txtboxBackupLocation.Text = job.BackupLocation;
            listboxSourceLocations.Items.Clear();
            listboxSourceLocations.Items.AddRange(job.SourceLocations.ToArray());
            txtRunAsUser.Text = job.RunAsUser;
            txtPassword.Text = job.Password;
            chkHighestPrivilege.Checked = job.HighestPrivilege;
            chkStorePassword.Checked = job.StorePassword;

            txtJobName.Enabled = false;
        }

        private void readTriggers(BackupJob job)
        {
            listViewTriggers.Items.Clear();
            string taskName = job.Server + "-" + job.Name;

            SecurityOptions securityOption = new SecurityOptions();
            securityOption.RunAsUser = job.RunAsUser;
            securityOption.Password = job.Password;
            securityOption.HighestPrivilege = job.HighestPrivilege;
            securityOption.StorePassword = job.StorePassword;

            TriggerCollection triggers = TaskManager.getTriggers(job.Server, taskName, securityOption);

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
                    TriggerEditDialog triggerDlg = new TriggerEditDialog(item.Tag as Trigger, false) { Text = "Edit Trigger" };
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
            try
            {
                ListView triggerView = sender as ListView;
                if (triggerView != null)
                {
                    btnEditTrigger_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isAuthenticate()
        {
            bool authenticate = false;

            string userName = txtRunAsUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                //using (var domainContext = new PrincipalContext(ContextType.Domain, _selectedServer)) // Check authentication in case of active directory
                //{
                //    authenticate = domainContext.ValidateCredentials(txtRunAsUser.Text.Trim(), txtPassword.Text.Trim());
                //    if (authenticate == false)
                //    {
                //        using (var machineContext = new PrincipalContext(ContextType.Machine, _selectedServer)) // Check machine authentication
                //        {
                //            authenticate = machineContext.ValidateCredentials(txtRunAsUser.Text.Trim(), txtPassword.Text.Trim());
                //        }
                //    }
                //}

                using (var domainContext = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
                {
                    authenticate = domainContext.ValidateCredentials(userName, password);
                    if (authenticate == false)
                    {
                        using (var machineContext = new PrincipalContext(ContextType.Machine))
                        {
                            authenticate = machineContext.ValidateCredentials(userName, password);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (var machineContext = new PrincipalContext(ContextType.Machine))
                {
                    authenticate = machineContext.ValidateCredentials(userName, password);
                }
            }

            return authenticate;
        }
    }
}