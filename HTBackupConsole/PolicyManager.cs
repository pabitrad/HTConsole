using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Configuration;

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
        public static List<Policy> getPolicies(string selectedServer)
        {
            List<Policy> policies = new List<Policy>();

            SqlCeCommand cmd = new SqlCeCommand("SELECT Name, BackupRetension, Compress FROM ScheduleJob WHERE Server = @SERVERNAME");
            SqlCeConnection sqlConnection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString());
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@SERVERNAME", selectedServer);

            SqlCeDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Policy policy = new Policy();
                policy.serverName = selectedServer;
                policy.jobName = dr["Name"].ToString();

                if (dr["BackupRetension"] == DBNull.Value)
                {
                    policy.backupRetension = 1;
                }
                else
                {
                    policy.backupRetension = Convert.ToInt32(dr["BackupRetension"]);
                }

                if (dr["Compress"] == DBNull.Value)
                {
                    policy.compress = false;
                }
                else
                {
                    policy.compress = Convert.ToBoolean(dr["Compress"]);                
                }

                policies.Add(policy);
            }

            return policies;
        }

        static public int updatePolicy(Policy policy)
        {
            string sqlString = @"UPDATE ScheduleJob SET BackupRetension = @BackupRetension, Compress = @Compress
                                                        WHERE Name = @JobName and Server = @NodeName";

            SqlCeCommand sqlCommand = new SqlCeCommand(sqlString);
            sqlCommand.Connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["HTConsoleConnectionString"].ToString());
            sqlCommand.Connection.Open();

            sqlCommand.Parameters.AddWithValue("@JobName", policy.jobName);
            sqlCommand.Parameters.AddWithValue("@NodeName", policy.serverName);
            sqlCommand.Parameters.AddWithValue("@BackupRetension", policy.backupRetension);
            sqlCommand.Parameters.AddWithValue("@Compress", policy.compress);

            return sqlCommand.ExecuteNonQuery();
        }
    }
}
