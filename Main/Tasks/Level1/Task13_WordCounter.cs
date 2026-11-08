using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(13, "Счётчик вхождений слов в тексте (Dictionary)",
    "Посчитать, сколько раз каждое слово встречается в тексте.",
    "Использовать Dictionary<string, int>",
    "Разбить текст на слова (по пробелам и знакам пунктуации)",
    "Привести слова к нижнему регистру",
    "Вывести пары «слово → количество», отсортированные по убыванию количества")]
public class Task13_WordCounter : ITask
{
    public void Run()
    {
        Console.WriteLine("Введите текст (например, 'Привет, мир! Привет всем.'):");
        string text = Console.ReadLine()!;

       
        string lowerText = text.ToLower();

        
        char[] delimiters = { ' ', '.', ',', '!', '?', ';', ':', '-', '(', ')', '"', '\'' };
        string[] words = lowerText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
            else
            {
                wordCount[word] = 1;
            }
        }

        
        var sortedList = new List<KeyValuePair<string, int>>(wordCount);

        
        for (int i = 0; i < sortedList.Count - 1; i++)
        {
            for (int j = 0; j < sortedList.Count - i - 1; j++)
            {
                if (sortedList[j].Value < sortedList[j + 1].Value)
                {
                    var temp = sortedList[j];
                    sortedList[j] = sortedList[j + 1];
                    sortedList[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("\nРезультат:");
        foreach (var pair in sortedList)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
