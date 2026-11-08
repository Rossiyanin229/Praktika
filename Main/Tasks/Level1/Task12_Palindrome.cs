using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(12, "Палиндром (без учёта регистра/пробелов)",
    "Проверить, является ли строка палиндромом.",
    "Игнорировать регистр (ToLower/ToUpper)",
    "Игнорировать пробелы и знаки пунктуации",
    "Не использовать LINQ Reverse",
    "Пустая строка и строка из одного символа — палиндром")]
public class Task12_Palindrome : ITask
{
    public void Run()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine()!;

        bool isPal = IsPalindrome(input);

        Console.WriteLine($"Является палиндромом: {isPal}");
    }

    private bool IsPalindrome(string text)
    {
        
        string lower = text.ToLower();

        
        string cleaned = "";
        foreach (char c in lower)
        {
            if (char.IsLetterOrDigit(c))
            {
                cleaned += c;
            }
        }

        
        if (cleaned.Length <= 1)
            return true;

        
        int left = 0;
        int right = cleaned.Length - 1;

        while (left < right)
        {
            if (cleaned[left] != cleaned[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }
}
