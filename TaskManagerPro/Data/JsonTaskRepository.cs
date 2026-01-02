using System.Text.Json;
using TaskManagerPro.Core.Models;

namespace TaskManagerPro.Data
{
    public class JsonTaskRepository : ITaskRepository
    {
        private const string FileName = "tasks.json";

        public List<TaskItem> GetAll()
        {
            if (!File.Exists(FileName))
            {
                return new List<TaskItem>();
            }

            var json = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }

        public void Save(List<TaskItem> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FileName, json);
        }
    }
}
