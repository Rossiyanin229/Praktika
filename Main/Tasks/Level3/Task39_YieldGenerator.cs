using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level3;

[TaskInfo(39, "yield return — генератор чётных чисел",
    "Реализовать генератор чётных чисел через yield return.",
    "Метод IEnumerable<int> GetEvenNumbers(int max) — возвращает чётные числа до max",
    "Реализовать именно через yield return, без промежуточного списка",
    "Продемонстрировать работу в foreach",
    "Дополнительно: показать ленивость — вывести сообщение внутри генератора и убедиться, что оно печатается по одному")]
public class Task39_YieldGenerator : ITask
{
    public void Run()
    {
        Console.WriteLine("=== Демонстрация работы yield return ===");
        Console.WriteLine("(Обрати внимание: строка 'Генерация числа X' появляется по одной, прямо перед выводом)\n");

        foreach (int number in GetEvenNumbers(10))
        {
            Console.WriteLine($"Получено из генератора: {number}");
        }

        Console.WriteLine("\n=== Ленивость в действии ===");
        Console.WriteLine("Если мы прервем цикл на середине, остальные числа не будут вычислены:");

        foreach (int number in GetEvenNumbers(100))
        {
            Console.WriteLine($"Получено: {number}");
            if (number >= 6)
            {
                Console.WriteLine("Прерываем цикл (break)!");
                break;
            }
        }
    }

    
    private IEnumerable<int> GetEvenNumbers(int max)
    {
        for (int i = 0; i <= max; i++)
        {
            if (i % 2 == 0)
            {
            
                Console.WriteLine($"  [Генерация числа {i}]");

                
                yield return i;
            }
        }
    }
}
