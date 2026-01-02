using TaskManagerPro.Core.Models;

public interface ITaskRepository
{
    List<TaskItem> GetAll();
    void Save(List<TaskItem> tasks);
}
