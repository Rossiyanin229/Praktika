using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(23, "Nullable-типы, ??, ?.",
    "Продемонстрировать работу с nullable.",
    "Метод int? FindValue(string key) — возвращает null, если ключа нет",
    "Использовать ?? для значения по умолчанию",
    "Использовать ?. для безопасного доступа к свойству объекта, который может быть null",
    "Использовать HasValue / Value с проверкой",
    "Продемонстрировать на примере с найденным и ненайденным ключом")]
public class Task23_NullableTypes : ITask
{
    
    private readonly Dictionary<string, int> _data = new Dictionary<string, int>
    {
        { "apple", 10 },
        { "banana", 20 }
    };

    public void Run()
    {
        Console.WriteLine("=== Тест 1: Использование ?? (оператор объединения с null) ===");
        
        int result1 = FindValue("apple") ?? -1;
        int result2 = FindValue("cherry") ?? -1; 
        Console.WriteLine($"Значение для 'apple': {result1}");  
        Console.WriteLine($"Значение для 'cherry': {result2}"); 
        Console.WriteLine();

        Console.WriteLine("=== Тест 2: Использование HasValue и Value ===");
        int? found = FindValue("banana");
        if (found.HasValue)
        {
            Console.WriteLine($"Ключ найден! Значение: {found.Value}");
        }

        int? notFound = FindValue("orange");
        if (!notFound.HasValue)
        {
            Console.WriteLine("Ключ 'orange' не найден (null).");
        }
        Console.WriteLine();

        Console.WriteLine("=== Тест 3: Использование ?. (безопасный доступ) ===");
        
        Person? person1 = new Person { Name = "Иван", Age = 30 };
        Person? person2 = null;

      
        Console.WriteLine($"Имя person1: {person1?.Name ?? "Объект null"}");
        Console.WriteLine($"Имя person2: {person2?.Name ?? "Объект null"}");
    }

    
    private int? FindValue(string key)
    {
        if (_data.TryGetValue(key, out int value))
        {
            return value;
        }
        return null; 
    }
}


public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}