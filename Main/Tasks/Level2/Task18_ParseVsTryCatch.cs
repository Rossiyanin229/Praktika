using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(18, "TryParse vs try/catch",
    "Сравнить два способа обработки некорректного ввода числа.",
    "Способ 1: int.TryParse — вернуть bool + значение через out",
    "Способ 2: int.Parse внутри try/catch — ловить FormatException",
    "Оба оформить отдельными методами",
    "Продемонстрировать на корректном и некорректном вводе")]
public class Task18_ParseVsTryCatch : ITask
{
    public void Run()
    {
        string[] testInputs = { "123", "abc", "45.6" };

        foreach (string input in testInputs)
        {
            Console.WriteLine($"--- Ввод: \"{input}\" ---");

           
            if (TryParseMethod(input, out int result1))
            {
                Console.WriteLine($"TryParse: Успех, число = {result1}");
            }
            else
            {
                Console.WriteLine("TryParse: Ошибка, это не число.");
            }

            
            int result2 = ParseWithTryCatch(input);
            if (result2 != int.MinValue) 
            {
                Console.WriteLine($"Parse + try/catch: Успех, число = {result2}");
            }
            else
            {
                Console.WriteLine("Parse + try/catch: Ошибка, поймано исключение.");
            }
            Console.WriteLine();
        }
    }

    
    private bool TryParseMethod(string input, out int value)
    {
        return int.TryParse(input, out value);
    }

    
    private int ParseWithTryCatch(string input)
    {
        try
        {
            return int.Parse(input);
        }
        catch (FormatException)
        {
            return int.MinValue; 
        }
    }
}
