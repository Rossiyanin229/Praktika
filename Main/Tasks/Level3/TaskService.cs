using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level3;

public class TaskService
{
    private readonly TaskRepository _repository;
    private List<TaskItem> _tasks;

    public TaskService(TaskRepository repository)
    {
        _repository = repository;
        _tasks = _repository.Load();
    }

    public void AddTask(string title)
    {
        int newId = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
        _tasks.Add(new TaskItem { Id = newId, Title = title, IsDone = false });
        _repository.Save(_tasks);
    }

    public void PrintAll()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
            return;
        }

        foreach (var task in _tasks)
        {
            Console.WriteLine(task);
        }
    }

    public bool MarkAsDone(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;

        task.IsDone = true;
        _repository.Save(_tasks);
        return true;
    }

    public bool DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;

        _tasks.Remove(task);
        _repository.Save(_tasks);
        return true;
    }
}
