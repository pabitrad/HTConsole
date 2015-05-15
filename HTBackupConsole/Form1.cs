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
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Xml;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.Win32;
using System.Threading;
using System.Collections.Specialized;
using HTBackupUserControl;
using HTConsoleCommonUtil;
using System.Reflection;
using System.Collections;

namespace HTBackupConsole
{
    public partial class Form1 : Form
    {
        //public event EventHandler InputControls_OnChange;

        int graphIncrement = 0;
        SqlCeConnection cn = new SqlCeConnection(HTConsoleHelper.ConnectionString);

        Server srv;
        ServerConnection conn;

        //JOBTYPE jobType = JOBTYPE.FULLBACKUP;

        //bool isDirty = false;

        public Form1()
        {
            InitializeComponent();
            //setControlsForDirtyCheck(tabPageServerBackup);
            populateMonitoringServers();

            populatePolicyTab();
        }

        //private void setControlsForDirtyCheck(Control window)
        //{
        //    foreach (Control subctrl in window.Controls)
        //    {
        //        if (subctrl is TextBox)
        //        {
        //            ((TextBox)subctrl).TextChanged +=
        //                new EventHandler(this.InputControls_OnChange);
        //        }
        //        else if (subctrl is CheckBox)
        //        {
        //            ((CheckBox)subctrl).CheckedChanged +=
        //                new EventHandler(InputControls_OnChange);
        //        }
        //        else if (subctrl is ListBox)
        //        {
        //            ListBox listBox = (ListBox)subctrl;
        //            ((INotifyCollectionChanged)listBox.Items).CollectionChanged += ListBox_CollectionChanged;
        //        }
        //        else if (subctrl is ComboBox)
        //        {
        //            ((ComboBox)subctrl).SelectedIndexChanged +=
        //                new EventHandler(InputControls_OnChange);
        //        }
        //    }
        //}


        private void populateMonitoringServers()
        {
            List<string> servers = HTConsoleHelper.getServers();
            if (servers.Count > 0)
            {
                cmbBoxMonitoringServers.DataSource = servers;
            }
        }

        private void populatePolicyTab()
        {
            string serverName = textBox1.Text;
            if (string.IsNullOrWhiteSpace(serverName))
            {
                return;
            }
            List<Policy> policies = PolicyManager.getPolicies(textBox1.Text);
            listBoxJobNames.Items.Clear();
           
            listBoxJobNames.Tag = policies;
            foreach (Policy policy in policies)
            {
                listBoxJobNames.Items.Add(policy.jobName);
            }
        }
        //private void InputControls_OnChange(object sender, EventArgs e)
        //{
        //    isDirty = true;
        //}

        //private void ListBox_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    isDirty = true;
        //}

        private void addHTBackupServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddServer AddServer = new AddServer();
            AddServer.Show();
        }

        private void deleteHTBackupServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveServer RemoveServer = new RemoveServer();
            RemoveServer.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            treeViewServer.Nodes.Clear();

            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM SCHEDULER ORDER BY SERVERNAME ASC");
            cmd.Connection = cn;

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TreeNode node = new TreeNode(dr["SERVERNAME"].ToString());

                    treeViewServer.Nodes.Add(node);
                }

                pageEssbaseBackup.setServerBackupType(ServerBackupType.EssbaseBackup);
                backupPageCluster.setServerBackupType(ServerBackupType.Cluster);

                //ServerPage.setRunningJobs(BackupJobScheduler.RunningJobs);
                //pageEssbaseBackup.setRunningJobs(BackupJobScheduler.RunningJobs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void populateMoniroingCategoryList(string machineName)
        {
            // Get a list of available performance counter categories
            PerformanceCounterCategory[] perfCounters = PerformanceCounterCategory.GetCategories(machineName);
            for (int i = 0; i < perfCounters.Length; i++)
            {
                // Add the category to the drop-down list
                lstCats.Items.Add(perfCounters[i].CategoryName);
            }

            try
            {

            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // textBox1.Text = e.Node.Text;

            try
            {

            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }

            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM SCHEDULER WHERE SERVERNAME = @SERVERNAME");
            cmd.Connection = cn;

            cmd.Parameters.AddWithValue("@SERVERNAME", e.Node.Text);

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBox1.Text = dr["SERVERNAME"].ToString().Trim();
                    textBox2.Text = dr["SERVERIP"].ToString();
                    textBox3.Text = dr["USER"].ToString();
                    textBox4.Text = dr["ESSUSER"].ToString();
                }

                ServerPage.setSelectedServer(textBox1.Text);
                pageEssbaseBackup.setSelectedServer(textBox1.Text);
                backupPageCluster.setSelectedServer(textBox1.Text);
                populatePolicyTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                if (rk != null)
                {
                    String[] instances = (String[])rk.GetValue("InstalledInstances");
                    if (instances != null && instances.Length > 0)
                    {
                        foreach (String element in instances)
                        {
                            if (element == "MSSQLSERVER")
                                lstLocalInstances.Items.Add(System.Environment.MachineName);
                            else
                                lstLocalInstances.Items.Add(System.Environment.MachineName + @"\" + element);
                        }
                    }

                   // Thread threadGetNetworkInstances = new Thread(GetNetworkInstances);
                   // threadGetNetworkInstances.Start();
                }

                // Get a list of available performance counter categories
                PerformanceCounterCategory[] perfCounters = PerformanceCounterCategory.GetCategories();
                if (perfCounters != null)
                {
                    for (int i = 1; i < perfCounters.Length; i++)
                    {
                        // Add the category to the drop-down list
                        lstCats.Items.Add(perfCounters[i].CategoryName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                cn.Open();
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }

            SqlCeCommand cmd = new SqlCeCommand("SELECT SERVERNAME FROM SCHEDULER ORDER BY SERVERNAME ASC");
            cmd.Connection = cn;

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["SERVERNAME"]);
                }

                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            treeViewServer.Nodes.Clear();

            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM SCHEDULER ORDER BY SERVERNAME ASC");
            cmd.Connection = cn;

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TreeNode node = new TreeNode(dr["SERVERNAME"].ToString());

                    treeViewServer.Nodes.Add(node);
                }
                //SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void serverInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupDirectory SetupDirectory = new SetupDirectory();
            SetupDirectory.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddServer AddServer = new AddServer();
            AddServer.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            RemoveServer RemoveServer = new RemoveServer();
            RemoveServer.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SetupDirectory SetupDirectory = new SetupDirectory();
            SetupDirectory.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            SrvControl SrvControl = new SrvControl();
            SrvControl.ShowDialog();
        }

        private void tmrCounter_Tick(object sender, EventArgs e)
        {
            float currVal;
            // Move to and get the latest value in the performance counter
            currVal = perfMain.NextValue();
            // Update the label with the value
            lblValue.Text = Math.Round(Convert.ToDouble(currVal.ToString()), 2) + "%";
            Graphics gfx = picGraph.CreateGraphics();
            Pen pn = new Pen(Color.Red, 1);
            gfx.DrawLine(pn, graphIncrement, 400, graphIncrement, 190 - (currVal * 2));

            graphIncrement += 2;
            if (graphIncrement > 1050)
            {
                picGraph.Invalidate();
                graphIncrement = 0;
            }
        }

        private void lstCats_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] instanceNames;
            System.Collections.ArrayList counters = new System.Collections.ArrayList();
            if (lstCats.SelectedIndex != -1)
            {
                System.Diagnostics.PerformanceCounterCategory mycat = new System.Diagnostics.PerformanceCounterCategory(this.lstCats.SelectedItem.ToString());
                // Remove the current contents of the list.
                this.lstCounters.Items.Clear();
                // Retrieve the counters.
                instanceNames = mycat.GetInstanceNames();
                if (instanceNames.Length == 0)
                {
                    counters.AddRange(mycat.GetCounters());
                }
                else
                {
                    for (int i = 0; i < instanceNames.Length; i++)
                    {
                        counters.AddRange(mycat.GetCounters(instanceNames[i]));
                    }
                }

                // Add the retrieved counters to the list.
                foreach (System.Diagnostics.PerformanceCounter counter in counters)
                {
                    this.lstCounters.Items.Add(counter.CounterName);
                }
            }
        }


        private void lstCounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the existing instance list
            lstInstances.Items.Clear();
            PerformanceCounterCategory perfCat = new PerformanceCounterCategory(lstCats.SelectedItem.ToString());
            string[] catInstances;
            catInstances = perfCat.GetInstanceNames();
            lstInstances.Items.Clear();
            foreach (string catInstance in catInstances)
            {
                lstInstances.Items.Add(catInstance);
            }
        }


        private void picGraph_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (lstCats.SelectedIndex != -1 && lstCounters.SelectedIndex != -1 && lstInstances.SelectedIndex != -1)
            {
                // Clear the graph
                picGraph.Invalidate();
                graphIncrement = 0;
                perfMain.CategoryName = lstCats.SelectedItem.ToString();
                perfMain.CounterName = lstCounters.SelectedItem.ToString();
                perfMain.InstanceName = lstInstances.SelectedItem.ToString();
                tmrCounter.Start();
            }
            else
            {
                MessageBox.Show("Please select a category, counter and instance first.", "Selection needed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Users Users = new Users();
            Users.Show();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCeCommand cm = new SqlCeCommand("UPDATE ESSAPP SET APPDIRECTORY = @DIRECTORY where ID=1");
            cm.Connection = cn;

            cm.Parameters.AddWithValue("@DIRECTORY", textBox15.Text);

            try
            {
                int affectedRows = cm.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Insert Success!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox15.Text = "";
                }
                else
                {
                    MessageBox.Show("Insert Failed!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM ESSAPP");
            cmd.Connection = cn;

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem it = new ListViewItem(dr["APPDIRECTORY"].ToString());

                    textBox15.Text = dr["APPDIRECTORY"].ToString();
                }

                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void lstLocalInstances_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValidateDBConnectivity())
                {
                    ddlDatabase.Items.Clear();

                    string sqlServerInstance = string.Empty;

                    if (this.tabServers.SelectedIndex == 0 && lstLocalInstances.SelectedItem != null)
                    {
                        sqlServerInstance = lstLocalInstances.SelectedItem.ToString();
                    }
                    else if (lstNetworkInstances.SelectedItem != null)
                    {
                        sqlServerInstance = lstNetworkInstances.SelectedItem.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Please select a SQL server instance.");
                        return;
                    }

                    if (chkWindowsAuthentication.Checked == true)
                    {
                        conn = new ServerConnection();
                        conn.ServerInstance = sqlServerInstance;
                    }
                    else
                    {
                        conn = new ServerConnection(sqlServerInstance, txtLogin.Text, txtPassword.Text);
                    }
                    srv = new Server(conn);
                    
                    foreach (Database db in srv.Databases)
                    {
                        ddlDatabase.Items.Add(db.Name);
                    }

                    MessageBox.Show("Connection successful.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + " \nPlease check login and password.");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "bak files (*.bak)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName.ToString();

            }
        }

        private void btnBackupDB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlDatabase.Text))
            {
                MessageBox.Show("Please select database from drop down list.");
                return;
            }

            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Please select backup file name.");
                return;
            }

            Backup bkp = new Backup();

            this.Cursor = Cursors.WaitCursor;
            this.dataGridView1.DataSource = string.Empty;
            try
            {
                string fileName = this.txtFileName.Text;
                string databaseName = this.ddlDatabase.SelectedItem.ToString();

                bkp.Action = BackupActionType.Database;
                bkp.Database = databaseName;
                bkp.Devices.AddDevice(fileName, DeviceType.File);
                bkp.Incremental = chkIncremental.Checked;
                this.progressBar1.Value = 0;
                this.progressBar1.Maximum = 100;
                this.progressBar1.Value = 10;

                bkp.PercentCompleteNotification = 10;
                bkp.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);

                bkp.SqlBackup(srv);
                MessageBox.Show("Database Backed Up To: " + fileName, "HTBackup Console");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.progressBar1.Value = 0;
            }
        }

        public void ProgressEventHandler(object sender, PercentCompleteEventArgs e)
        {
            this.progressBar1.Value = e.Percent;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlDatabase.Text))
            {
                MessageBox.Show("Please select database from drop down list.");
                return;
            }

            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Please select file name.");
                return;
            }

            Restore res = new Restore();

            this.Cursor = Cursors.WaitCursor;
            this.dataGridView1.DataSource = string.Empty;

            try
            {
                string fileName = this.txtFileName.Text;
                string databaseName = this.ddlDatabase.SelectedItem.ToString();

                res.Database = databaseName;
                res.Action = RestoreActionType.Database;
                res.Devices.AddDevice(fileName, DeviceType.File);

                this.progressBar1.Value = 0;
                this.progressBar1.Maximum = 100;
                this.progressBar1.Value = 10;

                res.PercentCompleteNotification = 10;
                res.ReplaceDatabase = true;
                res.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);
                res.SqlRestore(srv);

                MessageBox.Show("Restore of " + databaseName + " Complete!", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SmoException exSMO)
            {
                MessageBox.Show(exSMO.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.progressBar1.Value = 0;
            }
        }

        private void btnBackupLog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlDatabase.Text))
            {
                MessageBox.Show("Please select a database from drop down list.");
                return;
            }

            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Please select back up file name.");
                return;
            }

            Backup bkp = new Backup();

            Cursor = Cursors.WaitCursor;
            dataGridView1.DataSource = "";

            try
            {
                string strFileName = txtFileName.Text.ToString();
                string strDatabaseName = ddlDatabase.SelectedItem.ToString();

                bkp.Action = BackupActionType.Log;
                bkp.Database = strDatabaseName;

                bkp.Devices.AddDevice(strFileName, DeviceType.File);
                progressBar1.Value = 0;
                progressBar1.Maximum = 100;
                progressBar1.Value = 10;

                bkp.PercentCompleteNotification = 10;
                bkp.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);

                bkp.SqlBackup(srv);
                MessageBox.Show("Log Backed Up To: " + strFileName, "HTBackup");
            }
            catch (SmoException exSMO)
            {
                MessageBox.Show(exSMO.InnerException.Message);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
                progressBar1.Value = 0;
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (srv == null)
            {
                MessageBox.Show("Please connect to SQL server.");
                return;
            }

            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Please select back up file name.");
                return;
            }

            Restore rest = new Restore();
            string fileName = this.txtFileName.Text;

            this.Cursor = Cursors.WaitCursor;
            this.dataGridView1.DataSource = string.Empty;

            try
            {
                rest.Devices.AddDevice(fileName, DeviceType.File);
                bool verifySuccessful = rest.SqlVerify(srv);

                if (verifySuccessful)
                {
                    MessageBox.Show("Backup Verified!", "HTBackup");
                    DataTable dt = rest.ReadFileList(srv);
                    this.dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Backup NOT Verified!", "HTBackup");
                }
            }
            catch (SmoException exSMO)
            {
                MessageBox.Show(exSMO.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        delegate void SetMessageCallback(string text);

        private void AddNetworkInstance(string text)
        {
            if (this.lstNetworkInstances.InvokeRequired)
            {
                SetMessageCallback d = new SetMessageCallback(AddNetworkInstance);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.lstNetworkInstances.Items.Add(text);
            }
        }

        private void GetNetworkInstances()
        {
            DataTable dt = SmoApplication.EnumAvailableSqlServers(false);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AddNetworkInstance(dr["Name"].ToString());
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlBackup.SelectTab(serverInformationTabPage);
        }

        private void UpdateServerInfo_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand cm = new SqlCeCommand("UPDATE SCHEDULER SET [USER] = @ServerAdmin, ESSUSER = @EssBaseAdmin, SERVERIP = @ServerIP_Address  where SERVERNAME = @ServerName;");
                cm.Connection = new SqlCeConnection(HTConsoleHelper.ConnectionString);
                cm.Connection.Open();

                cm.Parameters.AddWithValue("@ServerName", textBox1.Text.Trim());
                cm.Parameters.AddWithValue("@ServerIP_Address", textBox2.Text.Trim());
                cm.Parameters.AddWithValue("@ServerAdmin", textBox3.Text.Trim());
                cm.Parameters.AddWithValue("@EssBaseAdmin", textBox4.Text.Trim());

                if (cm.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Server information updated successfully.");
                }
                cm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

//        private void insertJob(string selectedNode)
//        {
//            string startDate = dtpStartDate.Value.ToShortDateString();
//            string startTime = dtpStartTime.Value.ToShortTimeString();
//            string logFileLocation = txtboxLogFileLocation.Text;
//            string backupLocation = txtboxBackupLocation.Text;
//            string sourceLocations = getSourceLocations(listboxSourceLocations);
//            int incrementalInterval = (jobType == JOBTYPE.INCREMENTAL) ? (int)numericUpDownBackupIncremental.Value : 0;
//            int scheduleType = (int)cmbScheduleType.SelectedValue;

//            string sqlString = @"INSERT INTO ScheduleJob VALUES 
//                                (@Name, @Server, @BackupType, @StartDate, @StartTime, @SourceLocation, @BackupLocation, @LogDirLocation, @IncrementInterval, @ScheduleType)";

//            SqlCeCommand sqlCommand = new SqlCeCommand(sqlString);
//            sqlCommand.Connection = new SqlCeConnection(HTConsoleHelper.ConnectionString);
//            sqlCommand.Connection.Open();

//            sqlCommand.Parameters.AddWithValue("@Name", txtJobName.Text);
//            sqlCommand.Parameters.AddWithValue("@Server", selectedNode);
//            sqlCommand.Parameters.AddWithValue("@BackupType", jobType);
//            sqlCommand.Parameters.AddWithValue("@StartDate", startDate);
//            sqlCommand.Parameters.AddWithValue("@StartTime", startTime);
//            sqlCommand.Parameters.AddWithValue("@SourceLocation", sourceLocations);
//            sqlCommand.Parameters.AddWithValue("@BackupLocation", backupLocation);
//            sqlCommand.Parameters.AddWithValue("@LogDirLocation", logFileLocation);
//            sqlCommand.Parameters.AddWithValue("@IncrementInterval", incrementalInterval);
//            sqlCommand.Parameters.AddWithValue("@ScheduleType", scheduleType);

//            if (sqlCommand.ExecuteNonQuery() > 0)
//            {
//                MessageBox.Show("Job saved successfully.");
//            }
//        }

        private string getSourceLocations(ListBox listBox)
        {
            string sourceLocations = string.Empty;
            foreach (Object item in listBox.Items)
            {
                sourceLocations += item.ToString() + "|";
            }

            return sourceLocations;
        }

        private void tabControlEssbaseBackup_Selected(object sender, TabControlEventArgs e)
        {
            //if (tabControlEssbaseBackup.SelectedTab == tabPageEssbaseBackup)
            //{
            //    pageEssbaseBackup.setServerBackupType(ServerBackupType.EssbaseBackup);
            //}
        }

        private bool isValidateDBConnectivity()
        {
            if (chkWindowsAuthentication.Checked == false && string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Please enter login and password Or select windows authentication checkbox before selecting Connect button.");
                return false;
            }

            return true;
        }

        private void chkBoxLocalMachine_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkBoxLocalMachine.Checked)
                {
                    cmbBoxMonitoringServers.Enabled = false;
                    populateMoniroingCategoryList(Environment.MachineName);
                }
                else
                {
                    cmbBoxMonitoringServers.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }      
        }

        private void cmbBoxMonitoringServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxMonitoringServers.SelectedIndex > 0)
            {
                populateMoniroingCategoryList(cmbBoxMonitoringServers.Text);
                //populateMoniroingCategoryList("PABITRA-HP");
            }
        }

        private void chkWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWindowsAuthentication.Checked)
            {
                txtLogin.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtLogin.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tabControlBackup_Selected(object sender, TabControlEventArgs e)
        {
            //if (tabControlBackup.SelectedTab == tabPageCluster)
            //{
            //    backupPageCluster.setServerBackupType(ServerBackupType.Cluster);
            //}
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 3.3.1", "HTConsole");
        }

        private void btnSavePolicy_Click(object sender, EventArgs e)
        {
            string serverName = textBox1.Text;
            string jobName = listBoxJobNames.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(jobName) == false)
            {
                List<Policy> policies = listBoxJobNames.Tag as List<Policy>;
                Policy selectedPolicy = new Policy();
                foreach (Policy policy in policies)
                {
                    if (policy.jobName == jobName)
                    {
                        selectedPolicy = policy;
                        break;
                    }
                }

                selectedPolicy.backupRetension = (int)numericUpDownBackupRetension.Value;
                selectedPolicy.compress = chkBoxCompress.Checked;

                if (PolicyManager.updatePolicy(selectedPolicy) > 0)
                {
                    MessageBox.Show("Policy Saved successfully.", "HTConsole");
                }
            }
        }

        private void listBoxJobNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jobName = listBoxJobNames.SelectedItem.ToString();

            List<Policy> policies = listBoxJobNames.Tag as List<Policy>;
            foreach (Policy policy in policies)
            {
                if (policy.jobName == jobName)
                {
                    numericUpDownBackupRetension.Value = policy.backupRetension;
                    chkBoxCompress.Checked = policy.compress;
                    break;
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populatePolicyTab();
        }
    }
}