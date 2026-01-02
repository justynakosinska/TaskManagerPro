using TaskManagerPro.Core.Models;

namespace TaskManagerPro.Services
{
    public interface ITaskService
    {
        void Add(string title);
        void Complete(int id);
        void Remove(int id);
        List<TaskItem> GetAll();
    }
}