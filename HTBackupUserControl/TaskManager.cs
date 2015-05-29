using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.TaskScheduler;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace TaskManagerUtil
{
    public class SecurityOptions
    {
        string _runAsUser;
        string _password;
        bool _highestPrivilege;
        bool _storePassword;

        public string RunAsUser
        {
            get
            {
                return _runAsUser;
            }

            set
            {
                _runAsUser = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public bool HighestPrivilege
        {
            get
            {
                return _highestPrivilege;
            }

            set
            {
                _highestPrivilege = value;
            }
        }

        public bool StorePassword
        {
            get
            {
                return _storePassword;
            }

            set
            {
                _storePassword = value;
            }
        }
    }

    public class TaskManager
    {
        static public void createTask(string machineName, string taskName, SecurityOptions securityOptions,
                                      List<Trigger> triggerList, List<Microsoft.Win32.TaskScheduler.Action> actionList)
        {

            //ProcessStartInfo startInfo = new ProcessStartInfo("SCHTASKS.EXE");
            //startInfo.FileName = "cmd.exe";
            //startInfo.Verb = "runas";

            //Microsoft.Win32.TaskScheduler.Action action = actionList[0];
            //string argument = @"/K SCHTASKS.EXE /create /tn " + taskName + " /tr \"" + action.ToString() + "\" /sc daily /mo 4 /s " + machineName;

            //if (Environment.MachineName.ToLower() != machineName.ToLower())
            //{
            //   argument = argument + " /u " + securityOptions.RunAsUser + " /p " + securityOptions.Password;
            //}
            //startInfo.Arguments = argument;
            //string task = "SCHTASKS.EXE";

            //Process.Start(startInfo);

            using (TaskService ts = new TaskService(machineName, securityOptions.RunAsUser, machineName, securityOptions.Password))
            {
                try
                {
                    TaskFolder tf = getTaskFolder(ts);
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Task created by HTConsole.";
                    td.Triggers.AddRange(triggerList);
                    foreach (Microsoft.Win32.TaskScheduler.Action action in actionList)
                    {
                        td.Actions.Add(action);
                    }
                    if (securityOptions.HighestPrivilege)
                    {
                        td.Principal.RunLevel = TaskRunLevel.Highest;
                    }

                    TaskLogonType logonType = TaskLogonType.S4U;
                    if (securityOptions.StorePassword)
                    {
                        logonType = TaskLogonType.Password;
                    }
                    string runAsUser = String.Concat(Environment.UserDomainName, "\\", securityOptions.RunAsUser);
                    tf.RegisterTaskDefinition(taskName, td, TaskCreation.Create, runAsUser,
                                              securityOptions.Password, logonType);

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static TaskFolder getTaskFolder(TaskService ts)
        {
            TaskFolder tf = null;
            //using (TaskService ts = new TaskService())
            {
               try
               {
                    tf = ts.GetFolder(@"\HTConsole");
               }
               catch (FileNotFoundException exception)
               {
                   tf = ts.RootFolder.CreateFolder(@"\HTConsole");
               }
            }

            return tf;
        }

        public static TriggerCollection getTriggers(string machineName, string taskName, SecurityOptions securityOptions)
        {
            using (TaskService ts = new TaskService(machineName, securityOptions.RunAsUser, machineName, securityOptions.Password))
            {
                Task task = getTask(taskName, ts);
                if (task != null)
                {
                    return task.Definition.Triggers;
                }
            }

            return null;
        }

        public static void modifyTask(string machineName, string taskName, SecurityOptions securityOptions,
                                      List<Trigger> triggerList, List<Microsoft.Win32.TaskScheduler.Action> actionList)
        {
            using (TaskService ts = new TaskService(machineName, securityOptions.RunAsUser, machineName, securityOptions.Password))
            {
                Task task = getTask(taskName, ts);
                if (task != null)
                {
                    TaskDefinition def = task.Definition;
                    def.Triggers.Clear();
                    def.Triggers.AddRange(triggerList);

                    def.Actions.Clear();
                    foreach (Microsoft.Win32.TaskScheduler.Action action in actionList)
                    {
                        def.Actions.Add(action);
                    }

                    if (securityOptions.HighestPrivilege)
                    {
                        def.Principal.RunLevel = TaskRunLevel.Highest;
                    }
                    else
                    {
                        def.Principal.RunLevel = TaskRunLevel.LUA;
                    }

                    TaskLogonType logonType = TaskLogonType.S4U;
                    if (securityOptions.StorePassword)
                    {
                        logonType = TaskLogonType.Password;
                    }

                    string runAsUser = String.Concat(Environment.UserDomainName, "\\", securityOptions.RunAsUser);

                    TaskFolder tf = getTaskFolder(ts);
                    tf.RegisterTaskDefinition(taskName, def, TaskCreation.Update, runAsUser,
                                                securityOptions.Password, logonType);

                    //tf.RegisterTaskDefinition(taskName, def);
                }
            }
        }

        public static void deleteTask(string machineName, string taskName, SecurityOptions securityOptions)
        {
            using (TaskService ts = new TaskService(machineName, securityOptions.RunAsUser, machineName, securityOptions.Password))
            {
                Task task = getTask(taskName, ts);
                if (task != null)
                {
                    TaskFolder tf = getTaskFolder(ts);
                    tf.DeleteTask(taskName);
                }
            }
        }

        public static void enableTriggers(string machineName, string taskName, SecurityOptions securityOptions, bool enable)
        {
            using (TaskService ts = new TaskService(machineName, securityOptions.RunAsUser, machineName, securityOptions.Password))
            {
                Task task = getTask(taskName, ts);
                if (task != null)
                {
                    TaskDefinition def = task.Definition;
                    TriggerCollection triggers = def.Triggers;
                    List<Trigger> newTriggerList = new List<Trigger>();
                    foreach (Trigger trigger in triggers)
                    {
                        Trigger newTrigger = trigger.Clone() as Trigger;
                        newTrigger.Enabled = enable;
                        newTriggerList.Add(newTrigger);
                    }

                    def.Triggers.Clear();
                    def.Triggers.AddRange(newTriggerList);

                    if (securityOptions.HighestPrivilege)
                    {
                        def.Principal.RunLevel = TaskRunLevel.Highest;
                    }
                    else
                    {
                        def.Principal.RunLevel = TaskRunLevel.LUA;
                    }

                    TaskLogonType logonType = TaskLogonType.S4U;
                    if (securityOptions.StorePassword)
                    {
                        logonType = TaskLogonType.Password;
                    }

                    string runAsUser = String.Concat(Environment.UserDomainName, "\\", securityOptions.RunAsUser);

                    //using (TaskService ts = new TaskService(machineName, securityOptions.RunAsUser, machineName, securityOptions.Password))
                    {
                        TaskFolder tf = getTaskFolder(ts);

                        tf.RegisterTaskDefinition(taskName, def, TaskCreation.Update, runAsUser,
                                  securityOptions.Password, logonType);
                    }

                    //tf.RegisterTaskDefinition(taskName, def);
                }
            }
        }

        public static bool isTaskEnabled(string machineName, string taskName, SecurityOptions securityOptions)
        {
            using (TaskService ts = new TaskService(machineName, securityOptions.RunAsUser, machineName, securityOptions.Password))
            {
                Task task = getTask(taskName, ts);
                TaskDefinition def = task.Definition;
                TriggerCollection triggers = def.Triggers;
                foreach (Trigger trigger in triggers)
                {
                    if (trigger.Enabled == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool isTaskDisabled(string machineName, string taskName, SecurityOptions securityOptions)
        {
            using (TaskService ts = new TaskService(machineName, securityOptions.RunAsUser, machineName, securityOptions.Password))
            {
                Task task = getTask(taskName, ts);
                TaskDefinition def = task.Definition;
                TriggerCollection triggers = def.Triggers;
                foreach (Trigger trigger in triggers)
                {
                    if (trigger.Enabled == true)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static Task getTask(string taskName, TaskService ts)
        {
            TaskFolder tf = getTaskFolder(ts);

            Regex filter = new Regex(taskName);
            TaskCollection collection = tf.GetTasks(filter);

            if (collection == null || collection.Count == 0)
            {
                return null;
            }
            
            return collection[0];
        }
     }
}