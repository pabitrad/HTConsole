using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;
using Ionic.Zip;

namespace HTBackupConsole
{
    struct Policy
    {
        public string jobName;
        public string serverName;
        public int backupRetension;
        public bool compress;
    }

    class PolicyManager
    {
        private const string RETENTION_SUBFOLDER_NAME = "Retention";
        private const string RETENTION_FILE_EXTENSION = ".zip";
        private const string BACKUPJOB_FOLDER_SETTING = "BackupJobRootFolder";
        private const string POLICY_HANDLE_PERIOD_IN_HOURS_SETTING = "PolicyHandlePeriodInHours";

        private static System.Threading.Timer _policyTimer;

        public static List<Policy> getPolicies(string selectedServer)
        {
            List<Policy> policies = new List<Policy>();

            SqlCeCommand cmd =
                new SqlCeCommand("SELECT Name, BackupRetension, Compress FROM ScheduleJob WHERE Server = @SERVERNAME");
            SqlCeConnection sqlConnection =
                new SqlCeConnection(ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString());
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@SERVERNAME", selectedServer);

            SqlCeDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Policy policy = new Policy
                {
                    serverName = selectedServer,
                    jobName = dataReader["Name"].ToString(),
                    backupRetension = getBackupRetentionField(dataReader),
                    compress = getCompressField(dataReader)
                };
                policies.Add(policy);
            }

            return policies;
        }

        public static List<Policy> getAllPolicies()
        {
            List<Policy> policies = new List<Policy>();
            SqlCeCommand cmd = new SqlCeCommand("SELECT Name, BackupRetension, Compress, Server FROM ScheduleJob");
            SqlCeConnection sqlConnection =
                new SqlCeConnection(ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString());
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            SqlCeDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Policy policy = new Policy
                {
                    serverName = dataReader["Server"].ToString(),
                    jobName = dataReader["Name"].ToString(),
                    backupRetension = getBackupRetentionField(dataReader),
                    compress = getCompressField(dataReader)
                };
                policies.Add(policy);
            }
            dataReader.Close();
            return policies;
        }

        public static int updatePolicy(Policy policy)
        {
            string sqlString = @"UPDATE ScheduleJob SET BackupRetension = @BackupRetension, Compress = @Compress
                                                        WHERE Name = @JobName and Server = @NodeName";

            SqlCeCommand sqlCommand = new SqlCeCommand(sqlString);
            sqlCommand.Connection =
                new SqlCeConnection(ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString());
            sqlCommand.Connection.Open();

            sqlCommand.Parameters.AddWithValue("@JobName", policy.jobName);
            sqlCommand.Parameters.AddWithValue("@NodeName", policy.serverName);
            sqlCommand.Parameters.AddWithValue("@BackupRetension", policy.backupRetension);
            sqlCommand.Parameters.AddWithValue("@Compress", policy.compress);

            return sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Starts periodic policies handling.
        /// </summary>
        public static void runAutomaticPoliciesHandling()
        {
            if (_policyTimer != null)
            {
                return;
            }

            string backupJobRootFolder = getBackupJobRootFolderTrailingSlash();
            try {
                Directory.GetAccessControl(backupJobRootFolder);
            }
            catch (Exception)
            {
                string error = string.Format(
                    "Some problem caused with job's root folder access: \"{0}\". " +
                    "Policies automation handling will not start.\n" +
                    "Please, check folder existence and permissions for HTConsole, and try again."
                    , backupJobRootFolder);
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string periodHoursString = ConfigurationManager.AppSettings[POLICY_HANDLE_PERIOD_IN_HOURS_SETTING];
            int periodHours;
            if (!int.TryParse(periodHoursString, out periodHours))
            {
                MessageBox.Show(
                    "Invalid value PolicyHandlePeriodInHours in application config file, must be integer value.\n" +
                    "Policies automation handling will not start, please correct value and restart HTConsole.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int periodMilliseconds = (int) Math.Floor(TimeSpan.FromHours(periodHours).TotalMilliseconds);
            _policyTimer = new System.Threading.Timer(state => applyPolicies(), null, Timeout.Infinite, periodMilliseconds);
            _policyTimer.Change(0, periodMilliseconds);
        }

        /// <summary>
        /// Enumerates all entries of ScheduleJob table and apply job policies to appropriate jobs.
        /// Should NOT be called on UI thread.
        /// </summary>
        private static void applyPolicies()
        {
            var policies = getAllPolicies();
            compressJobs(policies);
            handleRetentions(policies);
        }

        /// <summary>
        /// Compress those jobs, for which compress policy flag is true.
        /// </summary>
        private static void compressJobs(List<Policy> policies) 
        {
            string backupJobRootFolder = getBackupJobRootFolderTrailingSlash();
            string retentionFolder = getRetentionFolderTrailingSlash();
            foreach (var policy in policies)
            {
                if (!policy.compress)
                {
                    continue;
                }

                string zipFileName = retentionFolder + policy.jobName + RETENTION_FILE_EXTENSION;
                string jobFolder = backupJobRootFolder + policy.jobName;

                try
                {
                    if (Directory.Exists(jobFolder) && !File.Exists(zipFileName))
                    {
                        if (!Directory.Exists(retentionFolder))
                        {
                            Directory.CreateDirectory(retentionFolder);
                        }
                        using (var zip = new ZipFile(policy.jobName + RETENTION_FILE_EXTENSION))
                        {
                            zip.AddDirectory(jobFolder);
                            zip.Save(zipFileName);
                        }
                    }
                }
                catch (Exception)
                {
                    string error = string.Format("Cannot compress folder \"{0}\" to \"{1}\" archive. Please, check system rights for HTConsole.", jobFolder, zipFileName);
                    //TODO some error logging
                }
            }
        }

        /// <summary>
        /// Check retention for all jobs and delete those job folders, 
        /// for which creation_date + policy_retention_days_count is less, than today's date.
        /// </summary>
        private static void handleRetentions(List<Policy> policies)
        {
            string backupJobRootFolder = getBackupJobRootFolderTrailingSlash();
            foreach (var policy in policies)
            {
                if (policy.backupRetension < 1)
                {
                    continue;
                }

                string targetFolder = backupJobRootFolder + policy.jobName;
                try
                {
                    if (Directory.Exists(targetFolder))
                    {
                        DateTime folderCreation = Directory.GetCreationTimeUtc(targetFolder);
                        DateTime expirationDate = folderCreation + TimeSpan.FromDays(policy.backupRetension);
                        if (DateTime.UtcNow > expirationDate)
                        {
                            Directory.Delete(targetFolder, true);
                        }
                    }
                }
                catch (Exception)
                {
                    string error = string.Format("Cannot handle retention policy for folder \"{0}\" Please, check system rights for this program.", targetFolder);
                    //TODO some error logging
                }
            }
        }

        /// <summary>
        /// Returns system path to backup job's root folder.
        /// </summary>
        private static string getBackupJobRootFolderTrailingSlash()
        {
            string settingsFolder = ConfigurationManager.AppSettings[BACKUPJOB_FOLDER_SETTING];
            return settingsFolder.TrimEnd('\\') + "\\";
        }

        /// <summary>
        /// Returns system path to backup job's retention folder.
        /// </summary>
        private static string getRetentionFolderTrailingSlash()
        {
            return getBackupJobRootFolderTrailingSlash() + RETENTION_SUBFOLDER_NAME.TrimEnd('\\') + "\\";
        }

        /// <summary>
        /// Retrieves BackupRetension field from SqlCeDataReader.
        /// </summary>
        private static int getBackupRetentionField(SqlCeDataReader dataReader)
        {
            object fieldValue = dataReader["BackupRetension"];
            return fieldValue == DBNull.Value ? 1 : Convert.ToInt32(fieldValue);
        }

        /// <summary>
        /// Retrieves Compress field from SqlCeDataReader.
        /// </summary>
        private static bool getCompressField(SqlCeDataReader dataReader)
        {
            object fieldValue = dataReader["Compress"];
            return fieldValue != DBNull.Value && Convert.ToBoolean(fieldValue);
        }
    }
}
