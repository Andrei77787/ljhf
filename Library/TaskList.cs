using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class TaskList
    {
        private string name { get; set; }
        private List<Task> tasks { get; set; }

        public TaskList(string name)
        {
            this.name = name;
        }

        ///<summary>
        /// Возвращает имя списка задач
        /// </summary>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Добавляет задачу в список задач
        /// </summary>
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        /// <summary>
        /// Возвращает список всех задач
        /// </summary>
        public List<Task> GetTasks()
        {
            return tasks;
        }

        /// <summary>
        /// удаляет задачу из списка задач
        /// </summary>
        public void Remove(Task task)
        {
            if (tasks.Contains(task))
            {
                tasks.Remove(task);
            }
        }

        /// <summary>
        /// Возвращает задачи запланированные на сегодня в хронологическом порядке
        /// </summary>
        public List<Task> GetTasksByToday()
        {
            var today = DateTime.Now.ToShortDateString();
            var tasksByToday = tasks.Where(t => t.Due.ToShortDateString() == today).ToList();
            return tasksByToday;
        }

        /// <summary>
        /// Возвращает задачи запланированные на завтра и позже в хронологическом порядке
        /// </summary>
        public List<Task> GetTasksByFuture()
        {
            var today = DateTime.Now;
            var tasksByToday = tasks.Where(t => t.Due > today).ToList();
            return tasksByToday;
        }
    }
}
