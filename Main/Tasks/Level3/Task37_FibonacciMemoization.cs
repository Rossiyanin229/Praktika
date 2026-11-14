using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Main.Common;

namespace Main.Tasks.Level3;

[TaskInfo(37, "Мемоизация Фибоначчи через Dictionary",
    "Реализовать мемоизированную функцию Фибоначчи.",
    "Обычная рекурсивная версия (для сравнения на маленьком N)",
    "Мемоизированная версия с Dictionary<int, long>",
    "Замерить время обеих на N = 30–35 через Stopwatch",
    "Вывести оба времени и разницу")]
public class Task37_FibonacciMemoization : ITask
{
   
    private readonly Dictionary<int, long> _memo = new Dictionary<int, long>();

    public void Run()
    {
        int n = 35;

        Console.WriteLine($"=== Вычисление Fibonacci({n}) ===\n");

        
        Stopwatch swNormal = Stopwatch.StartNew();
        long resultNormal = FibonacciNormal(n);
        swNormal.Stop();
        Console.WriteLine($"Обычная рекурсия: {resultNormal}");
        Console.WriteLine($"Время: {swNormal.ElapsedMilliseconds} мс\n");

        
        Stopwatch swMemo = Stopwatch.StartNew();
        long resultMemo = FibonacciMemo(n);
        swMemo.Stop();
        Console.WriteLine($"Мемоизация: {resultMemo}");
        Console.WriteLine($"Время: {swMemo.ElapsedMilliseconds} мс\n");

        
        long diff = swNormal.ElapsedMilliseconds - swMemo.ElapsedMilliseconds;
        Console.WriteLine($"Разница: {diff} мс (мемоизация быстрее в {swNormal.ElapsedMilliseconds / Math.Max(1, swMemo.ElapsedMilliseconds)} раз)");

        Console.WriteLine($"\nРезультаты совпадают: {resultNormal == resultMemo}");
    }

   
    private long FibonacciNormal(int n)
    {
        if (n <= 1) return n;
        return FibonacciNormal(n - 1) + FibonacciNormal(n - 2);
    }

   
    private long FibonacciMemo(int n)
    {
       
        if (_memo.ContainsKey(n))
        {
            return _memo[n];
        }

        
        long result;
        if (n <= 1)
        {
            result = n;
        }
        else
        {
            
            result = FibonacciMemo(n - 1) + FibonacciMemo(n - 2);
        }

        _memo[n] = result;
        return result;
    }
}
