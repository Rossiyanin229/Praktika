using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(4, "Чётность числа (два способа)",
    "Определить, чётное ли введённое число.",
    "Способ 1: через % 2 == 0",
    "Способ 2: через тернарный оператор ? :",
    "Оба способа реализовать отдельными методами",
    "Вывести результат обоих способов")]
public class Task04_EvenOdd : ITask
{
    public void Run()
    {
        Console.Write("Введите целое число: ");
        int number = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"Способ 1 (% 2 == 0): {CheckByModulo(number)}");
        Console.WriteLine($"Способ 2 (тернарный): {CheckByTernary(number)}");
    }

    
    private string CheckByModulo(int number)
    {
        if (number % 2 == 0)
            return "Чётное";
        else
            return "Нечётное";
    }

    
    private string CheckByTernary(int number)
    {
        return number % 2 == 0 ? "Чётное" : "Нечётное";
    }
}