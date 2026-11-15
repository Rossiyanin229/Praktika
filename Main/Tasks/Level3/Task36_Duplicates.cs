using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level3;

[TaskInfo(36, "Дубликаты в List (HashSet + GroupBy)",
    "Найти дубликаты в списке чисел двумя способами.",
    "Способ 1: через HashSet<int> — при добавлении проверять Contains",
    "Способ 2: через LINQ GroupBy(x => x).Where(g => g.Count() > 1)",
    "Оба способа оформить отдельными методами",
    "Продемонстрировать на списке с повторяющимися значениями")]
public class Task36_Duplicates : ITask
{
    public void Run()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 5, 1, 6, 7, 8, 9, 1, 2, 10 };

        Console.WriteLine("Исходный список: " + string.Join(", ", numbers));

        var duplicates1 = FindDuplicatesWithHashSet(numbers);
        var duplicates2 = FindDuplicatesWithLinq(numbers);

        Console.WriteLine("\nСпособ 1 (HashSet): " + string.Join(", ", duplicates1));
        Console.WriteLine("Способ 2 (LINQ):   " + string.Join(", ", duplicates2));

        
        var sorted1 = duplicates1.OrderBy(x => x).ToList();
        var sorted2 = duplicates2.OrderBy(x => x).ToList();
        Console.WriteLine($"\nРезультаты совпадают: {sorted1.SequenceEqual(sorted2)}");
    }

   
    private List<int> FindDuplicatesWithHashSet(List<int> list)
    {
        HashSet<int> seen = new HashSet<int>();
        HashSet<int> duplicates = new HashSet<int>();

        foreach (int num in list)
        {
           
            if (!seen.Add(num))
            {
                duplicates.Add(num);
            }
        }
        return duplicates.ToList();
    }

   
    private List<int> FindDuplicatesWithLinq(List<int> list)
    {
        return list
            .GroupBy(x => x)                  
            .Where(g => g.Count() > 1)        
            .Select(g => g.Key)              
            .ToList();
    }
}
