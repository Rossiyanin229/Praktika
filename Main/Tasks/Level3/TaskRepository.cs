using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;

namespace Main.Tasks.Level3;

public class TaskRepository
{
    private readonly string _filePath;

    public TaskRepository(string filePath = "tasks.json")
    {
        _filePath = filePath;
    }

    public List<TaskItem> Load()
    {
        if (!File.Exists(_filePath)) return new List<TaskItem>();

        try
        {
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
        catch (JsonException)
        {
            Console.WriteLine("Ошибка: файл поврежден. Создан новый список.");
            return new List<TaskItem>();
        }
    }

    public void Save(List<TaskItem> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}
