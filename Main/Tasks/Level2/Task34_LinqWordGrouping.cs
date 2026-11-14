using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(34, "LINQ: группировка слов по первой букве",
    "Сгруппировать слова по первой букве.",
    "Взять список слов (10+)",
    "Сгруппировать через LINQ GroupBy(w => w[0])",
    "Отсортировать группы по первой букве",
    "Внутри группы — отсортировать слова",
    "Вывести «Буква: слово1, слово2, ...»")]
public class Task34_LinqWordGrouping : ITask
{
    public void Run()
    {
        
        List<string> words = new List<string>
        {
            "яблоко", "банан", "Апельсин", "вишня", "арбуз",
            "брусника", "ананас", "виноград", "ягода", "белый",
            "автобус", "вода", "ёж", "яблоня"
        };

        Console.WriteLine("Исходный список: " + string.Join(", ", words));
        Console.WriteLine();

        
        var groupedWords = words
            
            .Select(w => w.ToLower())
           
            .GroupBy(w => w[0])
           
            .OrderBy(g => g.Key);

        Console.WriteLine("=== Результат группировки ===");

        
        foreach (var group in groupedWords)
        {
           
            var sortedWords = group.OrderBy(w => w);

           
            string wordsString = string.Join(", ", sortedWords);

            Console.WriteLine($"{group.Key}: {wordsString}");
        }
    }
}
