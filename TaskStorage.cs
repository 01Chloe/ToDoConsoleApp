using System.Text.Json;

namespace ToDoConsoleApp;

class TaskStorage
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
    private readonly string filePath = Path.Combine(AppContext.BaseDirectory, "todo.json");

    public List<TaskItem> Load()
    {
        if(!File.Exists(filePath))
        {
            return [];
        }

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? [];
    }

    public void Save(List<TaskItem> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, JsonOptions);
        File.WriteAllText(filePath, json);
    }
}
