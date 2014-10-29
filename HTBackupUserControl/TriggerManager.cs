using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using Microsoft.Win32.TaskScheduler;
using HTConsoleCommonUtil;
using System.Data;

namespace HTBackupUserControl
{
    class TriggerManager
    {
        static public int insertTrigger(Trigger trigger, string serverName, string jobName)
        {
            string sqlString = @"INSERT INTO [Trigger] (Server, Job, Type, Details, Status) 
                                VALUES (@Server, @Job, @Type, @Details, @Status) ;";

            SqlCeCommand sqlCommand = new SqlCeCommand(sqlString);
            sqlCommand.Connection = new SqlCeConnection(HTConsoleHelper.ConnectionString);
            sqlCommand.Connection.Open();

            int triggerType = (int)trigger.TriggerType;
            int triggerStatus = trigger.Enabled ? 1 : 0;

            sqlCommand.Parameters.AddWithValue("@Server", serverName);
            sqlCommand.Parameters.AddWithValue("@Job", jobName);
            sqlCommand.Parameters.AddWithValue("@Type", triggerType);
            sqlCommand.Parameters.AddWithValue("@Details", trigger.ToString());
            sqlCommand.Parameters.AddWithValue("@Status", triggerStatus);

            sqlCommand.ExecuteNonQuery();
            //SqlCeParameter IDParameter = new SqlCeParameter("@returnID", SqlDbType.Int);
            //IDParameter.Direction = ParameterDirection.Output;
            //sqlCommand.Parameters.Add(IDParameter);

            sqlCommand.CommandText = "SELECT @@IDENTITY";
            int id = Convert.ToInt32(sqlCommand.ExecuteScalar());

            return id;
        }

        static public void deleteTrigger(int triggerId)
        {
            SqlCeCommand cmd = new SqlCeCommand("DELETE FROM [Trigger] WHERE Id = @triggerId");
            cmd.Parameters.AddWithValue("@triggerId", triggerId);

            SqlCeConnection sqlConnection = new SqlCeConnection(HTConsoleHelper.ConnectionString);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
            cmd.Dispose();
        }

        static public SqlCeDataReader readTriggers(string serverName, string jobName)
        {
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM [Trigger] WHERE Server = @SERVERNAME AND Job = @JOBNAME");
            SqlCeConnection sqlConnection = new SqlCeConnection(HTConsoleHelper.ConnectionString);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@SERVERNAME", serverName);
            cmd.Parameters.AddWithValue("@JOBNAME", jobName);

            SqlCeDataReader dr = cmd.ExecuteReader();

            return dr;
        }
    }
}
