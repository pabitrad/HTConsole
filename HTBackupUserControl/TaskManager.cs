using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.TaskScheduler;
using System.IO;

namespace HTConsoleCommonUtil
{
    public class TaskManager
    {
        static public void createTask(string taskName, List<Trigger> triggerList, List<Microsoft.Win32.TaskScheduler.Action> actionList)
        {
            using (TaskService ts = new TaskService())
            {
                try
                {
                    TaskFolder tf = getTaskFolder();
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Task created by HTConsole.";
                    td.Triggers.AddRange(triggerList);
                    foreach (Microsoft.Win32.TaskScheduler.Action action in actionList)
                    {
                        td.Actions.Add(action);
                    }
                    td.Principal.RunLevel = TaskRunLevel.Highest;
                    tf.RegisterTaskDefinition(taskName, td);
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
            TaskFolder tf = getTaskFolder();
            Task task = tf.Tasks[taskName];

            if (task != null)
            {
                return task.Definition.Triggers;
            }

            return null;
        }

        public static void modifyTask(string taskName, List<Trigger> triggerList, List<Microsoft.Win32.TaskScheduler.Action> actionList)
        {
            TaskFolder tf = getTaskFolder();
            Task task = tf.Tasks[taskName];

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

                tf.RegisterTaskDefinition(taskName, def);
            }
        }

        public static void deleteTask(string taskName)
        {
            TaskFolder tf = getTaskFolder();
            Task task = tf.Tasks[taskName];

            if (task != null)
            {
                tf.DeleteTask(taskName);
            }
        }

        public static void enableTriggers(string taskName, bool enable)
        {

            TaskFolder tf = getTaskFolder();
            Task task = tf.Tasks[taskName];

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
                tf.RegisterTaskDefinition(taskName, def);
            }
        }

        public static bool isTaskEnabled(string taskName)
        {
            TaskFolder tf = getTaskFolder();
            Task task = tf.Tasks[taskName];
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
            TaskFolder tf = getTaskFolder();
            Task task = tf.Tasks[taskName];
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
     }
}