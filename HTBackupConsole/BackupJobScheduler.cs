using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTConsoleCommonUtil
{
    class BackupJobScheduler
    {
        private static readonly List<BackupJob> _backupJobs = null;
        private static readonly ArrayList _listJobNames = null;

        static BackupJobScheduler()
        {
            _listJobNames = new ArrayList();
            _backupJobs = new List<BackupJob>();
        }

        public static ArrayList RunningJobs
        {
            get
            {
                return _listJobNames;
            }
        }

        static public void addJob(BackupJob job)
        {
            _backupJobs.Add(job);
            _listJobNames.Add(job.Server + "-" + job.Name);
        }

        static public void removeJob(BackupJob job)
        {
            //stop timer
            _backupJobs.Remove(job);
            _listJobNames.Remove(job.Server + "-" + job.Name);
        }

        static public BackupJob getJob(string serverName, string jobName)
        {
            foreach (BackupJob job in _backupJobs)
            {
                if (job.Server == serverName && job.Name == jobName)
                {
                    return job;
                }
            }

            return null;
        }
    }
}
