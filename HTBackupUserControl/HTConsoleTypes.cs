using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTConsoleCommonUtil
{
    public enum JOBTYPE
    {
        FULLBACKUP = 1,
        INCREMENTAL = 2
    };

    //public enum SCHEDULETYPE
    //{
    //    Daily = 1,
    //    Weekly = 2,
    //    Monthly = 3
    //};

    public enum ServerBackupType
    {
        ServerBackup = 1,
        EssbaseBackup = 2,
        Cluster = 3
    };
}
