using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HTConsoleCommonUtil;
using System.IO;
using System.Threading;

namespace HTBackupConsole
{
    static class Program
    {
        const string _logFile = "HTConsoleLog.txt";
        static private StreamWriter _logWritter = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                _logWritter = File.AppendText(_logFile);

                Login loginForm = new Login();
                loginForm.Show();

                Application.Run(loginForm);
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            _logWritter.WriteLine(DateTime.Now.ToLongTimeString() + " : " + e.Exception.Message + Environment.NewLine);
            MessageBox.Show(e.Exception.Message, "Unhandled Thread Exception");
            // here you can log the exception ...
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string logMessage = (e.ExceptionObject as Exception).Message + ((Exception)e.ExceptionObject).StackTrace;

            _logWritter.WriteLine(DateTime.Now.ToLongTimeString() + " : " + logMessage + Environment.NewLine);
            MessageBox.Show(logMessage, "Unhandled UI Exception");
            // here you can log the exception ...
        }
    }
}
