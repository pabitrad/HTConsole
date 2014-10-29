using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HTConsoleCommonUtil;
using System.IO;

namespace HTBackupConsole
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Login loginForm = new Login();
                loginForm.Show();

                Application.Run(loginForm);
            }
            //else
            //{
            //    try
            //    {
            //        string server = args[0];
            //        string jobName = args[1];
                    
            //        Directory.SetCurrentDirectory(Application.StartupPath);

            //        BackupJob job = HTConsoleHelper.getSelectedJob(server, jobName);
            //        if (job != null)
            //        {
            //            job.executeJob();
            //        }
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }
    }
}
