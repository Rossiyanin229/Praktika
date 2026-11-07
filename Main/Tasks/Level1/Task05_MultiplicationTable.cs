using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(5, "Таблица умножения 10×10",
    "Вывести таблицу умножения 10×10.",
    "Использовать вложенные циклы for",
    "Выровнять столбцы",
    "Заголовки строк/столбцов — приветствуются")]
public class Task05_MultiplicationTable : ITask
{
    public void Run()
    {
        
        Console.Write("    "); 
        for (int j = 1; j <= 10; j++)
        {
            Console.Write($"{j,4}");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 44));

        
        for (int i = 1; i <= 10; i++)
        {
            
            Console.Write($"{i,3} |");

            for (int j = 1; j <= 10; j++)
            {
                
                Console.Write($"{i * j,4}");
            }
            Console.WriteLine();
        }
    }
}