using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(6, "Сумма цифр числа (строка + арифметика)",
    "Найти сумму цифр введённого числа.",
    "Способ 1: через ToString() и int.Parse",
    "Способ 2: через while и остаток от деления",
    "Оба способа оформить отдельными методами",
    "Отрицательные числа — брать модуль")]
public class Task06_DigitSum : ITask
{
    public void Run()
    {
        Console.Write("Введите целое число: ");
        int number = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"Способ 1 (строка): {SumByString(number)}");
        Console.WriteLine($"Способ 2 (арифметика): {SumByMath(number)}");
    }

    
    private int SumByString(int number)
    {
        
        string numStr = Math.Abs(number).ToString();
        int sum = 0;

        foreach (char c in numStr)
        {
            sum += int.Parse(c.ToString());
        }

        return sum;
    }

    
    private int SumByMath(int number)
    {
        
        int n = Math.Abs(number);
        int sum = 0;

        while (n > 0)
        {
            sum += n % 10; 
            n /= 10;       
        }

        return sum;
    }
}