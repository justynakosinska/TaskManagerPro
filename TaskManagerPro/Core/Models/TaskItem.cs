using TaskManagerPro.Core.Enums;
namespace TaskManagerPro.Core.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Core.Enums.TaskStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
