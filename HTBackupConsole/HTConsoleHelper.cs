using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Globalization;

namespace HTConsoleCommonUtil
{
    class HTConsoleHelper
    {
        static Dictionary<JOBTYPE, string> jobTypeDictionary = new Dictionary<JOBTYPE, string> {
                { JOBTYPE.FULLBACKUP, "Full" },
                { JOBTYPE.INCREMENTAL, "Incremental"  }
            };

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString();
            }
        }

        public static string TimestampSeparator
        {
            get { return "-"; }//TODO use in policy manager
        }

        public static List<string> getJobNames(string selectedServer)
        {
            List<string> jobNames = new List<string>();

            SqlCeCommand cmd = new SqlCeCommand("SELECT Name FROM ScheduleJob WHERE Server = @SERVERNAME");
            SqlCeConnection sqlConnection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString());
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@SERVERNAME", selectedServer);

            SqlCeDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                jobNames.Add(dr["Name"].ToString());
            }

            return jobNames;
        }

        public static string getJobType(JOBTYPE jobType)
        {
            return jobTypeDictionary[jobType];
        }

        public static string getHTBackupInstallDirectory()
        {
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM INSTALLINFO");
            SqlCeConnection sqlConnection = new SqlCeConnection(ConnectionString);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            SqlCeDataReader dr = cmd.ExecuteReader();
            string htBackupInstallDirectory = string.Empty;

            if (dr.Read())
            {
                htBackupInstallDirectory = dr["DIRECTORY"].ToString();
            }

            sqlConnection.Close();
            dr.Close();
            dr.Dispose();

            return htBackupInstallDirectory;
        }

        public static string getHTClusterInstallDirectory()
        {
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM INSTALLINFO");
            SqlCeConnection sqlConnection = new SqlCeConnection(ConnectionString);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            SqlCeDataReader dr = cmd.ExecuteReader();
            string htBackupInstallDirectory = string.Empty;

            if (dr.Read())
            {
                htBackupInstallDirectory = dr["ClustureDirectory"].ToString();
            }

            sqlConnection.Close();
            dr.Close();
            dr.Dispose();

            //htBackupInstallDirectory = htBackupInstallDirectory.Replace(':', '$');

            return htBackupInstallDirectory;
        }

        public static List<string> getServers()
        {
            SqlCeCommand cmd = new SqlCeCommand("SELECT SERVERNAME FROM SCHEDULER ORDER BY SERVERNAME ASC");
            string connString = String.Empty;
            List<string> serverList = new List<string>();

            if (ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"] !=null)
            {
                SqlCeConnection sqlConnection = new SqlCeConnection(ConnectionString);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                serverList.Add("---Select Server---");
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    serverList.Add(dr["SERVERNAME"].ToString());
                }
            }

            return serverList;
        }

        public static string getEssAppDirectory()
        {
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM ESSAPP");
            SqlCeConnection sqlConnection = new SqlCeConnection(ConnectionString);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            SqlCeDataReader dr = cmd.ExecuteReader();
            string appDirectory = string.Empty;

            if (dr.Read())
            {
                appDirectory = dr["APPDIRECTORY"].ToString();
            }

            sqlConnection.Close();
            dr.Close();
            dr.Dispose();

            return appDirectory;
        }

        public static BackupJob getSelectedJob(string serverName, string jobName)
        {
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM ScheduleJob WHERE Server = @ServerName AND Name = @JobName");
            SqlCeConnection sqlConnection = new SqlCeConnection(ConnectionString);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@ServerName", serverName);
            cmd.Parameters.AddWithValue("@JobName", jobName);

            SqlCeDataReader dr = cmd.ExecuteReader();
            BackupJob job = null;
            if (dr.Read())
            {
                job = new BackupJob();
                job.Name = dr["Name"].ToString();
                job.Server = dr["Server"].ToString();
                job.JobType = (JOBTYPE)(dr["BackupType"]);
                //job.IncrementInterval = Convert.ToInt32(dr["IncrementInterval"]);
                job.BackupLocation = dr["BackupLocation"].ToString();
                job.LogFileLocation = dr["LogDirLocation"].ToString();
                job.SourceLocations = getSourceLocations(dr["SourceLocation"].ToString());
                job.BackupType = (ServerBackupType)(dr["ServerBackupType"]);
                job.RunAsUser = dr["RunAsUser"].ToString();
                job.Password = dr["Password"].ToString();
                job.HighestPrivilege = Convert.ToBoolean(dr["HighestPrivilege"]);
                job.StorePassword = Convert.ToBoolean(dr["StorePassword"]);
            }

            sqlConnection.Close();
            dr.Close();
            dr.Dispose();

            return job;
        }

        public static List<string> getSourceLocations(string strSourceLocation)
        {
            string[] separators = { "|" };
            string[] locations = strSourceLocation.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            List<string> sourceLocations = new List<string>();
            foreach (var location in locations)
            {
                sourceLocations.Add(location);
            }

            return sourceLocations;
        }
    }
}