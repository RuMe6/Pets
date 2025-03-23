using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace TaskManager
{
    internal class TaskContext
    {
        private const string _fileName = "tasks.json";
        private List<Task> tasks = new();

        public TaskContext()
        {
            LoadTasks(); 
        }

        public void AddTask(Task task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);

            SaveTask();
        }

        public void IsCompletedMark(int taskId)
        {
            var task = tasks.Find(t => t.Id == taskId);

            if (task != null)
            {
                task.IsCompleted = true;
                SaveTask();
            }
        }
            
        public List<Task> GetAllTasks() => tasks;

        public void SaveTask()
        {
            File.WriteAllText(_fileName, JsonConvert.SerializeObject(tasks, Formatting.Indented));
        }

        private void LoadTasks()
        {
            if (File.Exists(_fileName))
            {
                tasks = JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText(_fileName)) 
                    ?? new List<Task>();
            }
        }
    }
}