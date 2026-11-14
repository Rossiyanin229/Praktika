using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(10, "Сортировка пузырьком + вставками",
    "Отсортировать массив двумя алгоритмами.",
    "Реализовать BubbleSort и InsertionSort отдельными методами",
    "Оба — без LINQ и Array.Sort",
    "Замерить время каждого через Stopwatch на массиве 10 000 элементов")]
public class Task10_Sorting : ITask
{
    public void Run()
    {
        const int size = 10000;
        Random rnd = new Random();

        
        int[] arrayForBubble = new int[size];
        for (int i = 0; i < size; i++)
        {
            arrayForBubble[i] = rnd.Next(1, 100000);
        }

        
        int[] arrayForInsertion = (int[])arrayForBubble.Clone();

        Console.WriteLine($"Сгенерирован массив из {size} элементов.\n");

        
        Stopwatch swBubble = Stopwatch.StartNew();
        BubbleSort(arrayForBubble);
        swBubble.Stop();
        Console.WriteLine($"Сортировка пузырьком: {swBubble.ElapsedMilliseconds} мс");

        
        Stopwatch swInsertion = Stopwatch.StartNew();
        InsertionSort(arrayForInsertion);
        swInsertion.Stop();
        Console.WriteLine($"Сортировка вставками: {swInsertion.ElapsedMilliseconds} мс");

       
        bool isEqual = true;
        for (int i = 0; i < size; i++)
        {
            if (arrayForBubble[i] != arrayForInsertion[i])
            {
                isEqual = false;
                break;
            }
        }
        Console.WriteLine($"\nМассивы отсортированы одинаково: {isEqual}");
    }

    
    private void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    
    private void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;

            
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }
}