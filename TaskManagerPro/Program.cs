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
            Console.WriteLine("1. Pokaż wszystkie zadania");
            Console.WriteLine("2. Dodaj zadanie");
            Console.WriteLine("3. Zakończ zadanie");
            Console.WriteLine("4. Usuń zadanie");
            Console.WriteLine("5. Wyjście");
            Console.Write("Wybierz opcję: ");

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
                        Console.WriteLine("Nieprawidłowa opcja.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }
    }

    static void ShowTasks(ITaskService service)
    {
        var tasks = service.GetAll();
        if (!tasks.Any())
        {
            Console.WriteLine("Brak zadań.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id} | {task.Title} | Status: {task.Status} | Utworzone: {task.CreatedAt}");
        }
    }

    static void AddTask(ITaskService service)
    {
        Console.Write("Podaj tytuł zadania: ");
        string title = Console.ReadLine();
        service.Add(title);
        Console.WriteLine("Zadanie dodane.");
    }

    static void CompleteTask(ITaskService service)
    {
        Console.Write("Podaj ID zadania do zakończenia: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            service.Complete(id);
            Console.WriteLine("Zadanie zakończone.");
        }
        else
        {
            Console.WriteLine("Nieprawidłowe ID.");
        }
    }

    static void RemoveTask(ITaskService service)
    {
        Console.Write("Podaj ID zadania do usunięcia: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            service.Remove(id);
            Console.WriteLine("Zadanie usunięte.");
        }
        else
        {
            Console.WriteLine("Nieprawidłowe ID.");
        }
    }
}
