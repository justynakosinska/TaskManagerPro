using TaskManagerPro.Core.Enums;
using TaskManagerPro.Core.Models;
using TaskManagerPro.Data;

namespace TaskManagerPro.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository repository;
        private List<TaskItem> tasks;

        public TaskService(ITaskRepository repository)
        {
            this.repository = repository;
            tasks = repository.GetAll();
        }

        public void Add(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception("Tytuł zadania nie może być pusty.");
            }

            int newId = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;

            var task = new TaskItem
            {
                Id = newId,
                Title = title,
                Status = Core.Enums.TaskStatus.New,
                CreatedAt = DateTime.Now
            };

            tasks.Add(task);
            repository.Save(tasks);
        }

        public void Complete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                throw new Exception("Nie znaleziono zadania o takim ID.");
            }

            task.Status = Core.Enums.TaskStatus.Completed;
            repository.Save(tasks);
        }

        public void Remove(int id)
        {
            tasks.RemoveAll(t => t.Id == id);
            repository.Save(tasks);
        }

        public List<TaskItem> GetAll()
        {
            return tasks;
        }
    }
}