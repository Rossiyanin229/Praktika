using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(22, "params-метод + перегрузка",
    "Написать метод суммы с params и его перегрузку.",
    "Sum(params int[] numbers) — сумма произвольного числа чисел",
    "Перегрузка Sum(int[] numbers) — та же логика для массива",
    "Продемонстрировать: Sum(1, 2, 3), Sum(new[] {1, 2, 3}), Sum()",
    "Пустой вызов — вернуть 0")]
public class Task22_ParamsOverload : ITask
{
    public void Run()
    {
        Console.WriteLine($"Sum(1, 2, 3) = {Sum(1, 2, 3)}");
        Console.WriteLine($"Sum(new[] {{ 1, 2, 3 }}) = {Sum(new[] { 1, 2, 3 })}");
        Console.WriteLine($"Sum() = {Sum()}");
    }

    
    private int Sum(params int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            return 0;

        int total = 0;
        foreach (int num in numbers)
        {
            total += num;
        }
        return total;
    }

    
    
}
