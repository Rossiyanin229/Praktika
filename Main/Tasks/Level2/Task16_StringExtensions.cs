using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(16, "Методы расширения для string",
    "Написать extension-методы для string.",
    "Реализовать в статическом классе StringExtensions",
    "Методы: IsPalindrome(), WordCount(), ReverseString()",
    "Методы должны быть public static с this string первым параметром",
    "Продемонстрировать вызов на 2–3 строках")]
public class Task16_StringExtensions : ITask
{
    public void Run()
    {
        string test1 = "А роза упала на лапу Азора";
        string test2 = "hello world";
        string test3 = "abc";

        Console.WriteLine($"Строка 1: \"{test1}\"");
        Console.WriteLine($"  Реверс: \"{test1.ReverseString()}\"");
        Console.WriteLine($"  Палиндром: {test1.IsPalindrome()}");
        Console.WriteLine($"  Слов: {test1.WordCount()}");
        Console.WriteLine();

        Console.WriteLine($"Строка 2: \"{test2}\"");
        Console.WriteLine($"  Реверс: \"{test2.ReverseString()}\"");
        Console.WriteLine($"  Палиндром: {test2.IsPalindrome()}");
        Console.WriteLine($"  Слов: {test2.WordCount()}");
        Console.WriteLine();

        Console.WriteLine($"Строка 3: \"{test3}\"");
        Console.WriteLine($"  Реверс: \"{test3.ReverseString()}\"");
        Console.WriteLine($"  Палиндром: {test3.IsPalindrome()}");
        Console.WriteLine($"  Слов: {test3.WordCount()}");
    }
}