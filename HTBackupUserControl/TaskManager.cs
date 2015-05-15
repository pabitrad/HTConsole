using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.TaskScheduler;
using System.IO;
using System.Text.RegularExpressions;

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
        static public void createTask(string taskName, SecurityOptions securityOptions,
                                      List<Trigger> triggerList, List<Microsoft.Win32.TaskScheduler.Action> actionList)
        {
            //using (TaskService ts = new TaskService("PABITRA-HP", "pabitra", "PABITRA-HP", "muna1969"))
            using (TaskService ts = new TaskService())
            {
                try
                {
                    TaskFolder tf = getTaskFolder();
                    TaskDefinition td = ts.NewTask();
                    //td.Principal.UserId = "SYSTEM";
                    //td.Principal.LogonType = TaskLogonType.S4U;
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

        public static TaskFolder getTaskFolder()
        {
            TaskFolder tf = null;
            using (TaskService ts = new TaskService())
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

        public static TriggerCollection getTriggers(string taskName)
        {
            Task task = getTask(taskName);
            if (task != null)
            {
                return task.Definition.Triggers;
            }

            return null;
        }

        public static void modifyTask(string taskName, SecurityOptions securityOptions,
                                      List<Trigger> triggerList, List<Microsoft.Win32.TaskScheduler.Action> actionList)
        {
            Task task = getTask(taskName);
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
                TaskFolder tf = getTaskFolder();                
                tf.RegisterTaskDefinition(taskName, def, TaskCreation.Update, runAsUser,
                                          securityOptions.Password, logonType);

                //tf.RegisterTaskDefinition(taskName, def);
            }
        }

        public static void deleteTask(string taskName)
        {
            Task task = getTask(taskName);
            if (task != null)
            {
                TaskFolder tf = getTaskFolder();
                tf.DeleteTask(taskName);
            }
        }

        public static void enableTriggers(string taskName, SecurityOptions securityOptions, bool enable)
        {
            Task task = getTask(taskName);
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

                TaskFolder tf = getTaskFolder();

                tf.RegisterTaskDefinition(taskName, def, TaskCreation.Update, runAsUser,
                          securityOptions.Password, logonType);

                //tf.RegisterTaskDefinition(taskName, def);
            }
        }

        public static bool isTaskEnabled(string taskName)
        {
            Task task = getTask(taskName);
            TaskDefinition def = task.Definition;
            TriggerCollection triggers = def.Triggers;
            foreach (Trigger trigger in triggers)
            {
                if (trigger.Enabled == false)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool isTaskDisabled(string taskName)
        {
            Task task = getTask(taskName);
            TaskDefinition def = task.Definition;
            TriggerCollection triggers = def.Triggers;
            foreach (Trigger trigger in triggers)
            {
                if (trigger.Enabled == true)
                {
                    return false;
                }
            }

            return true;
        }

        private static Task getTask(string taskName)
        {
            TaskFolder tf = getTaskFolder();

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