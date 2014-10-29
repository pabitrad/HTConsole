using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using Microsoft.Win32.TaskScheduler;
using HTConsoleCommonUtil;

namespace HTConsoleCommonUtil
{
    class BackupJob
    {
        private string _name;
        private string _server;
        private JOBTYPE _jobType;
        private List<string> _sourceLocations;
        private string _backupLocation;
        private string _logFileLocation;
        private int _incrementInterval;
        private ServerBackupType _serverBackupType;

        public System.Threading.Timer _jobTimer;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Server
        {
            get
            {
                return _server;
            }

            set
            {
                _server = value;
            }
        }

        public JOBTYPE JobType
        {
            get
            {
                return _jobType;
            }

            set
            {
                _jobType = value;
            }
        }

        public List<string> SourceLocations
        {
            get
            {
                return _sourceLocations;
            }

            set
            {
                _sourceLocations = value;
            }
        }

        public string BackupLocation
        {
            get
            {
                return _backupLocation;
            }

            set
            {
                _backupLocation = value;
            }
        }

        public string LogFileLocation
        {
            get
            {
                return _logFileLocation;
            }

            set
            {
                _logFileLocation = value;
            }
        }

        public int IncrementInterval
        {
            get
            {
                return _incrementInterval;
            }

            set
            {
                _incrementInterval = value;
            }
        }

        public ServerBackupType BackupType
        {
            get
            {
                return _serverBackupType;
            }

            set
            {
                _serverBackupType = value;
            }
        }

        //public void createTimer()
        //{
        //    TimeSpan currentTime = DateTime.Now - DateTime.Now.Date;
        //    TimeSpan timeDiff = StartTime - currentTime;

        //    if (currentTime > StartTime)  // crosses over midnight
        //        timeDiff += TimeSpan.FromTicks(TimeSpan.TicksPerDay);
        //    int totalMilliseconds = (int)timeDiff.TotalMilliseconds;

        //    int runInterval = 24 * 60 * 60 * 1000; // for daily full type backup jobs.
        //    if (JobType == JOBTYPE.INCREMENTAL)
        //    {
        //        runInterval = IncrementInterval * 60 * 1000;
        //    }
        //    _jobTimer = new System.Threading.Timer(new TimerCallback(JobTimerCallBack), this, totalMilliseconds, runInterval);
        //    //executeJob();
        //}

        public void enableTaskTriggers(bool enable)
        {
            TaskManager.enableTriggers(Server + "-" + Name, enable);
        }

        public bool isTaskEnabled()
        {
            return TaskManager.isTaskEnabled(Server + "-" + Name);
        }

        public void stopTimer()
        {
            _jobTimer.Dispose();
            _jobTimer = null;
        }

        public List<Microsoft.Win32.TaskScheduler.Action> getActions()
        {
            List<Microsoft.Win32.TaskScheduler.Action> listActions = new List<Microsoft.Win32.TaskScheduler.Action>();
            string application = string.Empty;
            string executionCommand = string.Empty;

            switch (BackupType)
            {
                case ServerBackupType.ServerBackup:
                case ServerBackupType.EssbaseBackup:
                    application = "PowerShell";
                    string backupAppDirectory = HTConsoleHelper.getHTBackupInstallDirectory();
                    executionCommand = "$now=Get-Date -format \"dd-MM-yyyy-HH.mm.ss\";";
                    executionCommand += "mkdir " + BackupLocation + "\\" + "$now" + ";";

                    foreach (var sourceLocation in SourceLocations)
                    {
                        //string executionCommand = @"/C \\Micror-pc\e$\Projects\Odesk\Backup-Bruno\HTBackup-HTCluster\HTBase\HTBackup\HTBase.exe ";
                        //executionCommand += "\\" + Server + "\\";
                        executionCommand += (backupAppDirectory + "\\" + "HTBase.exe ");

                        if (JobType == JOBTYPE.FULLBACKUP)
                        {
                            executionCommand += "/full ";
                        }
                        else if (JobType == JOBTYPE.INCREMENTAL)
                        {
                            executionCommand += "/incremental ";
                        }

                        executionCommand += ("/logfile=\"" + LogFileLocation + "\\HTBase.log\" /r /y ");

                        executionCommand += ("\"" + sourceLocation + "\"");
                        executionCommand += " ";

                        string backupStorage = BackupLocation + "/" + "$now";

                        executionCommand += ("\"" + backupStorage + "\"");
                        executionCommand += "  >>  \"";

                        if (JobType == JOBTYPE.FULLBACKUP)
                        {
                            executionCommand += (LogFileLocation + "\\HTBaseFullBackup.log\"");
                        }
                        else if (JobType == JOBTYPE.INCREMENTAL)
                        {
                            executionCommand += (LogFileLocation + "\\HTBaseIncrementalBackup.log\"");
                        }

                        executionCommand += ";";
                    }

                    listActions.Add(new ExecAction(application, executionCommand, null));
                    break;

                case ServerBackupType.Cluster:
                    application = "cmd ";
                    string clusterDirectory = HTConsoleHelper.getHTClusterInstallDirectory();
                    foreach (var sourceLocation in SourceLocations)
                    {
                        executionCommand = @"/C \\" + Server + "\\";
                        executionCommand += (clusterDirectory + "\\" + "HTCluster.exe ");
                        if (JobType == JOBTYPE.FULLBACKUP)
                        {
                            executionCommand += "/full ";
                        }
                        else if (JobType == JOBTYPE.INCREMENTAL)
                        {
                            executionCommand += "/incremental ";
                        }
                        executionCommand += ("/logfile=\"" + LogFileLocation + "\\HTCluster.log\" /r /y ");
                        executionCommand += ("\"" + sourceLocation + "\"");
                        executionCommand += " ";

                        executionCommand += ("\"" + BackupLocation + "\"");
                        executionCommand += "  >>  \"";

                        if (JobType == JOBTYPE.FULLBACKUP)
                        {
                            executionCommand += (LogFileLocation + "\\HTClusterFullReplication.log\"");
                        }
                        else if (JobType == JOBTYPE.INCREMENTAL)
                        {
                            executionCommand += (LogFileLocation + "\\HTClusterIncrementalReplica.log\"");
                        }

                        listActions.Add(new ExecAction(application, executionCommand, null));
                    }
                    break;
            }

            return listActions;
        }

        //private void JobTimerCallBack(object state)
        //{
        //    try
        //    {
        //        // execute the job in intervals determined by the methd
        //        BackupJob backupJob = (BackupJob)(state);
        //        if (backupJob != null)
        //        {
        //            if (IsScheduledForToday())
        //            {
        //                executeJob();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log error message
        //    }
        //}

        /// <summary>
        /// </summary>
        //public void executeJob()
        //{
        //    try
        //    {
        //        //TODO:have one variable backupAppDirectory
        //        string backupAppDirectory = HTConsoleHelper.getHTBackupInstallDirectory();
        //        string clusterDirectory = HTConsoleHelper.getHTClusterInstallDirectory();

        //        foreach (var sourceLocation in SourceLocations)
        //        {
        //            string application = @"cmd";
        //            //string executionCommand = @"/C \\Micror-pc\e$\Projects\Odesk\Backup-Bruno\HTBackup-HTCluster\HTBase\HTBackup\HTBase.exe ";
        //            string executionCommand = @"/C \\" + Server + "\\";

        //            switch (BackupType)
        //            {
        //                case ServerBackupType.ServerBackup:
        //                case ServerBackupType.EssbaseBackup:
        //                    executionCommand += (backupAppDirectory + "\\" + "HTBase.exe ");
        //                    break;

        //                case ServerBackupType.Cluster:
        //                    executionCommand += (clusterDirectory + "\\" + "HTCluster.exe ");
        //                    break;
        //            }

        //            if (JobType == JOBTYPE.FULLBACKUP)
        //            {
        //                executionCommand += "/full ";
        //            }
        //            else if (JobType == JOBTYPE.INCREMENTAL)
        //            {
        //                executionCommand += "/incremental ";
        //            }

        //            switch (BackupType)
        //            {
        //                case ServerBackupType.ServerBackup:
        //                case ServerBackupType.EssbaseBackup:
        //                    executionCommand += ("/logfile=\"" + LogFileLocation + "\\HTBase.log\" /r /y ");
        //                    break;

        //                case ServerBackupType.Cluster:
        //                    executionCommand += ("/logfile=\"" + LogFileLocation + "\\HTCluster.log\" /r /y ");
        //                    break;
        //            }

        //            executionCommand += ("\"" + sourceLocation + "\"");
        //            executionCommand += " ";

        //            string timeStamp = string.Empty;
        //            if (BackupType == ServerBackupType.ServerBackup || BackupType == ServerBackupType.EssbaseBackup)
        //            {
        //                timeStamp = "/" + DateTime.Now.ToString("dd-MM-yyyy-HH.mm.ss");
        //            }

        //            string backupStorage = BackupLocation + timeStamp;

        //            executionCommand += ("\"" + backupStorage + "\"");
        //            executionCommand += "  >>  \"";

        //            switch (BackupType)
        //            {
        //                case ServerBackupType.ServerBackup:
        //                case ServerBackupType.EssbaseBackup:
        //                    if (JobType == JOBTYPE.FULLBACKUP)
        //                    {
        //                        executionCommand += (LogFileLocation + "\\HTBaseFullBackup.log\"");
        //                    }
        //                    else if (JobType == JOBTYPE.INCREMENTAL)
        //                    {
        //                        executionCommand += (LogFileLocation + "\\HTBaseIncrementalBackup.log\"");
        //                    }
        //                    break;

        //                case ServerBackupType.Cluster:
        //                    if (JobType == JOBTYPE.FULLBACKUP)
        //                    {
        //                        executionCommand += (LogFileLocation + "\\HTClusterFullReplication.log\"");
        //                    }
        //                    else if (JobType == JOBTYPE.INCREMENTAL)
        //                    {
        //                        executionCommand += (LogFileLocation + "\\HTClusterIncrementalReplica.log\"");
        //                    }
        //                    break;
        //            }

        //            bool exists = Directory.Exists(backupStorage);
        //            if (!exists)
        //                Directory.CreateDirectory(backupStorage);

        //            using (TaskService ts = new TaskService())
        //            {
        //                string taskName = "HTCocnsole" + DateTime.Now.ToString("ddmmyyyyhhmmss");
        //                TaskDefinition td = ts.NewTask();
        //                td.RegistrationInfo.Description = "HTBackup task";
        //                td.Triggers.Add(new TimeTrigger { StartBoundary = DateTime.Now, Enabled = true });

        //                td.Actions.Add(new ExecAction(application, executionCommand));
        //                td.Principal.RunLevel = TaskRunLevel.Highest;

        //                Task regTask = ts.RootFolder.RegisterTaskDefinition(taskName, td);
        //                regTask.Run(null);
        //                Thread.Sleep(5000);
        //                ts.RootFolder.DeleteTask(taskName);
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        File.WriteAllText(LogFileLocation + "\\HTBaseFullBackup.log", ex.Message);
        //    }
        //}        
    }
}