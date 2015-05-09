using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Diagnostics;
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

    struct JobBackupLocation
    {
        public string backupLocation;
        public Policy policy;
    }

    class PolicyManager
    {
        private const string RETENTION_SUBFOLDER_NAME = "Retention";
        private const string RETENTION_FILE_EXTENSION = ".zip";
        private const string POLICY_HANDLE_PERIOD_IN_HOURS_SETTING = "PolicyHandlePeriodInHours";
        private static readonly object _policyHandlingSyncObject = new object();

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

        public static List<JobBackupLocation> getJobsBackupLocations()
        {
            SqlCeCommand cmd = new SqlCeCommand("SELECT Name, BackupLocation, BackupRetension, Compress, Server FROM ScheduleJob");
            SqlCeConnection sqlConnection =
                new SqlCeConnection(ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString());
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            var jobsBackupLocations = new List<JobBackupLocation>();
            SqlCeDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Policy backupPolicy = new Policy
                {
                    serverName = dataReader["Server"].ToString(),
                    jobName = dataReader["Name"].ToString(),
                    backupRetension = getBackupRetentionField(dataReader),
                    compress = getCompressField(dataReader)
                };
                JobBackupLocation jobBackupLocation = new JobBackupLocation
                {
                    backupLocation = dataReader["BackupLocation"].ToString(),
                    policy = backupPolicy,
                };
                jobsBackupLocations.Add(jobBackupLocation);
            }
            dataReader.Close();
            return jobsBackupLocations;
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
        /// Starts periodic jobBackupLocations handling.
        /// </summary>
        public static void runAutomaticPoliciesHandling()
        {
            if (_policyTimer != null)
            {
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
        /// Enumerates all entries of ScheduleJob table and apply job policies to appropriate jobs backup locations.
        /// Should NOT be called on UI thread.
        /// </summary>
        private static void applyPolicies()
        {
            lock (_policyHandlingSyncObject)
            {
                var policies = getJobsBackupLocations();
                compressJobs(policies);
                handleRetentions(policies);
            }
        }

        /// <summary>
        /// Compress those jobs backups, for which compress policy flag is true.
        /// </summary>
        private static void compressJobs(List<JobBackupLocation> jobBackupLocations) 
        {
            foreach (var backupLocation in jobBackupLocations)
            {
                if (!backupLocation.policy.compress)
                {
                    continue;
                }

                string backupJobRootFolder = getBackupJobRootFolderTrailingSlash(backupLocation.backupLocation);
                if (!isDirectoryAccessed(backupJobRootFolder))
                {
                    continue;
                }
                string retentionFolder = getRetentionFolderTrailingSlash(backupJobRootFolder);
                var backupJobRootSubFolders = Directory.EnumerateDirectories(backupJobRootFolder)
                    .Select(folder => folder.TrimEnd('\\') + "\\");
                foreach (var timestampFolder in backupJobRootSubFolders)
                {
                    if (isRetentionFolder(timestampFolder))
                    {
                        continue;
                    }
                    string timestampFolderName = Path.GetFileName(Path.GetDirectoryName(timestampFolder));
                    string zipFilePath = retentionFolder + timestampFolderName + RETENTION_FILE_EXTENSION;
                    
                    try
                    {
                        if (Directory.Exists(timestampFolder) && !File.Exists(zipFilePath))
                        {
                            if (!Directory.Exists(retentionFolder))
                            {
                                Directory.CreateDirectory(retentionFolder);
                            }
                            using (var zip = new ZipFile(timestampFolderName + RETENTION_FILE_EXTENSION))
                            {
                                zip.AddDirectory(timestampFolder);
                                zip.Save(zipFilePath);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        string error = string.Format(
                            "Cannot compress folder \"{0}\" to \"{1}\" archive. Please, check system rights for HTConsole.",
                            timestampFolder, zipFilePath);
                        Debug.Assert(false, error);
                        //TODO some error logging
                    }
                }
            }
        }

        /// <summary>
        /// Check retention for all job's backups and delete those backup folders, 
        /// for which creation_date + policy_retention_days_count is less, than today's date.
        /// </summary>
        private static void handleRetentions(List<JobBackupLocation> backupLocationWithPolicies)
        {
            foreach (var backupLocation in backupLocationWithPolicies)
            {
                if (backupLocation.policy.backupRetension < 1)
                {
                    continue;
                }

                string backupJobRootFolder = getBackupJobRootFolderTrailingSlash(backupLocation.backupLocation);
                if (!isDirectoryAccessed(backupJobRootFolder))
                {
                    continue;
                }
                var backupJobRootSubFolders = Directory.EnumerateDirectories(backupJobRootFolder)
                    .Select(folder => folder.TrimEnd('\\') + "\\");
                foreach (var timestampFolder in backupJobRootSubFolders)
                {
                    if (isRetentionFolder(timestampFolder))
                    {
                        continue;
                    }

                    try
                    {
                        if (Directory.Exists(timestampFolder))
                        {
                            DateTime folderCreation = Directory.GetCreationTimeUtc(timestampFolder);
                            DateTime expirationDate = folderCreation + TimeSpan.FromDays(backupLocation.policy.backupRetension);
                            if (DateTime.UtcNow > expirationDate)
                            {
                                Directory.Delete(timestampFolder, true);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        string error = string.Format(
                            "Cannot handle retention policy for folder \"{0}\" Please, check system rights for this program.",
                            timestampFolder);
                        Debug.Assert(false, error);
                        //TODO some error logging
                    }
                }
            }
        }

        /// <summary>
        /// Returns system path to backup job's root folder.
        /// </summary>
        private static string getBackupJobRootFolderTrailingSlash(string backupLocation)
        {
            return backupLocation.TrimEnd('\\') + "\\";
        }

        /// <summary>
        /// Returns system path to backup job's retention folder.
        /// </summary>
        private static string getRetentionFolderTrailingSlash(string backupJobLocation)
        {
            return getBackupJobRootFolderTrailingSlash(backupJobLocation) + RETENTION_SUBFOLDER_NAME.TrimEnd('\\') + "\\";
        }

        private static bool isRetentionFolder(string folder)
        {
            string folderName = Path.GetFileName(Path.GetDirectoryName(folder));
            return String.Equals(folderName, RETENTION_SUBFOLDER_NAME, StringComparison.InvariantCultureIgnoreCase);
        }

        private static bool isDirectoryAccessed(string directoryPath)
        {
            bool isAccessed;
            try
            {
                isAccessed = Directory.Exists(directoryPath);
            }
            catch (Exception)
            {
                isAccessed = false;
            }
            if (!isAccessed)
            {
                string error = string.Format(
                    "Some problem caused with job's root folder access: \"{0}\". " +
                    "Policies will not handled.\n" +
                    "Please, check folder existence and permissions for HTConsole, and try again."
                    , directoryPath);
                Debug.Assert(false, error);
                //TODO some error logging
                return false;
            }
            return true;
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
