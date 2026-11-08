using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(9, "Массивы: min/max/sum/avg",
    "Для массива чисел найти минимум, максимум, сумму и среднее.",
    "Заполнить массив случайными числами 1–100, размер 20",
    "Реализовать без LINQ",
    "Оформить 4 отдельных метода",
    "Пустой массив — обработать")]
public class Task09_ArrayStats : ITask
{
    public void Run()
    {
        
        int[] numbers = new int[20];
        Random rnd = new Random();

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = rnd.Next(1, 101);
        }

        
        Console.WriteLine("Массив: " + string.Join(", ", numbers));
        Console.WriteLine();

        
        Console.WriteLine($"Минимум: {FindMin(numbers)}");
        Console.WriteLine($"Максимум: {FindMax(numbers)}");
        Console.WriteLine($"Сумма: {FindSum(numbers)}");
        Console.WriteLine($"Среднее: {FindAverage(numbers):F2}");
    }

    
    private int FindMin(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Массив пуст");

        int min = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min) min = arr[i];
        }
        return min;
    }

    
    private int FindMax(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Массив пуст");

        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max) max = arr[i];
        }
        return max;
    }

    
    private int FindSum(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;

        int sum = 0;
        foreach (int num in arr)
        {
            sum += num;
        }
        return sum;
    }

   
    private double FindAverage(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;

        
        return (double)FindSum(arr) / arr.Length;
    }
}