using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using Main.Common;

namespace Main.Menu;


public class LevelMenu
{
    private readonly int _level;

    public LevelMenu(int level)
    {
        _level = level;
    }

    public void Show()
    {
        // Находим задания для этого уровня
        var tasks = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => typeof(ITask).IsAssignableFrom(t) && t.GetCustomAttribute<TaskInfoAttribute>() != null)
            .Select(t => new { Type = t, Info = t.GetCustomAttribute<TaskInfoAttribute>()! })
            .Where(x => x.Info.Number >= (_level - 1) * 15 + 1 && x.Info.Number <= _level * 15)
            .OrderBy(x => x.Info.Number)
            .ToList();

        if (tasks.Count == 0)
        {
            Console.WriteLine("\nВ этом уровне пока нет заданий.");
            Console.WriteLine("Нажмите Enter для возврата...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine($"\n--- Уровень {_level} ---");
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Info.Number}. {task.Info.Title}");
        }

        Console.Write("\nВыберите задание (или 0 для выхода): ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber))
        {
            var selectedTask = tasks.FirstOrDefault(t => t.Info.Number == taskNumber);
            if (selectedTask != null)
            {
                Console.Clear();
                ConsoleHelper.PrintHeader($"Задание {selectedTask.Info.Number}. {selectedTask.Info.Title}");

                Console.WriteLine("Описание:");
                Console.WriteLine($"  {selectedTask.Info.Description}");
                Console.WriteLine("\nТребования:");
                foreach (var req in selectedTask.Info.Requirements)
                    Console.WriteLine($"  - {req}");

                Console.WriteLine(new string('-', 50));
                Console.WriteLine("[запуск решения...]\n");

                var instance = (ITask)Activator.CreateInstance(selectedTask.Type)!;
                instance.Run();

                Console.WriteLine("\nНажмите Enter для возврата в меню...");
                Console.ReadLine();
            }
        }
    }
}
