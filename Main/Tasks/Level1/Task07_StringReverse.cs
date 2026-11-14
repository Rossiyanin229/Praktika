using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(7, "Реверс строки без LINQ",
    "Перевернуть введённую строку.",
    "Не использовать Array.Reverse и LINQ",
    "Реализовать через цикл for от конца к началу",
    "Пустая строка и строка из одного символа — обрабатываются корректно")]
public class Task07_StringReverse : ITask
{
    public void Run()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine()!;

        string reversed = ReverseString(input);

        Console.WriteLine($"Результат: \"{reversed}\"");
    }

    private string ReverseString(string input)
    {
        
        if (string.IsNullOrEmpty(input) || input.Length == 1)
            return input;

        
        char[] result = new char[input.Length];

        
        for (int i = 0; i < input.Length; i++)
        {
            result[i] = input[input.Length - 1 - i];
        }

        
        return new string(result);
    }
}
