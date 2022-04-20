using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Application
    {
        public static Application application { get; set; }
        public List<TaskList> taskLists { get; set; }

        private Application()
        {
            taskLists = new List<TaskList>();
        }

        /// </summary>
        /// Возвращает ссылку на экземпляр приложения, а в его отсутствие создает экземпляр
        /// </summary>
        public Application GetApplication()
        {
            if (application == null)
            {
                return new Application();
            }

            return application;
        }

        /// </summary>
        /// Создает список задач с указанным именем и добавляет его в taskLists
        /// </summary>
        public void CreateTaskList(string name)
        {
            taskLists.Add(new TaskList(name));
        }

        /// </summary>
        /// Возвращает имена списков задач
        /// </summary>
        public List<string> GetTaskListNames()
        {
            var names = taskLists.Select(t => t.GetName()).ToList();
            return names;
        }

        /// </summary>
        ///  Возвращает список задач по имени списка
        ///  </summary>
        public TaskList GetTaskListNames(string name)
        {
            var taskList = taskLists.FirstOrDefault(t => t.GetName() == name);
            return taskList;
        }

        /// </summary>
        /// Получает задачи запланированные на сегодня в хронологическом порядке
        /// </summary>
        public List<Task> GetTasksByToday()
        {
            List<Task> tasks = new List<Task>();

            foreach (var taskList in taskLists)
            {
                tasks.AddRange(taskList.GetTasksByToday());
            }

            return tasks;
        }

        /// </summary>
        /// Получает задачи запланированные завтра и позже в хронологическом порядке
        /// </summary>
        public List<Task> GetTasksByFuture()
        {
            List<Task> tasks = new List<Task>();

            foreach (var taskList in taskLists)
            {
                tasks.AddRange(taskList.GetTasksByFuture());
            }

            return tasks;
        }
    }
}
