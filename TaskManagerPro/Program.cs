using TaskManagerPro.Core.Enums;
using TaskManagerPro.Data;
using TaskManagerPro.Services;

class Program
{
    static void Main()
    {
        ITaskRepository repository = new JsonTaskRepository();
        ITaskService taskService = new TaskService(repository);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Task Manager Pro ===");
            Console.WriteLine("1. Show all tasks");
            Console.WriteLine("2. Add task");
            Console.WriteLine("3. Complete task");
            Console.WriteLine("4. Remove task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        ShowTasks(taskService);
                        break;
                    case "2":
                        AddTask(taskService);
                        break;
                    case "3":
                        CompleteTask(taskService);
                        break;
                    case "4":
                        RemoveTask(taskService);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void ShowTasks(ITaskService service)
    {
        var tasks = service.GetAll();
        if (!tasks.Any())
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id} | {task.Title} | Status: {task.Status} | Created: {task.CreatedAt}");
        }
    }

    static void AddTask(ITaskService service)
    {
        Console.Write("Enter task title: ");
        string title = Console.ReadLine();
        service.Add(title);
        Console.WriteLine("Task added.");
    }

    static void CompleteTask(ITaskService service)
    {
        Console.Write("Enter the ID of the task to complete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            service.Complete(id);
            Console.WriteLine("Task completed.");
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    static void RemoveTask(ITaskService service)
    {
        Console.Write("Enter the ID of the task to remove: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            service.Remove(id);
            Console.WriteLine("Task removed.");
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }
}
