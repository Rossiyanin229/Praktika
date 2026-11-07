using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(1, "Hello, World + текущая дата",
    "Вывести приветствие и текущую дату.",
    "Использовать Console.WriteLine",
    "Получить текущую дату через DateTime.Now")]
public class Task01_HelloWorld : ITask
{
    public void Run()
    {
        Console.WriteLine("Hello, World!");
        
        Console.WriteLine($"Текущая дата: {DateTime.Now:dd.MM.yyyy}");
    }
}