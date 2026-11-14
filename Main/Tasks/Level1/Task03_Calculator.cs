using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(3, "Калькулятор с обработкой деления на ноль",
    "Принимать два числа и оператор (+, -, *, /), выводить результат.",
    "Оператор обрабатывать через switch",
    "При делении на ноль — сообщение об ошибке, не ронять приложение",
    "Ввод чисел — через double.TryParse")]
public class Task03_Calculator : ITask
{
    public void Run()
    {
        double num1, num2;

        Console.Write("Введите первое число: ");
        while (!double.TryParse(Console.ReadLine(), out num1))
        {
            Console.Write("Ошибка! Введите корректное число: ");
        }

        Console.Write("Введите оператор (+, -, *, /): ");
        string op = Console.ReadLine()!;

        Console.Write("Введите второе число: ");
        while (!double.TryParse(Console.ReadLine(), out num2))
        {
            Console.Write("Ошибка! Введите корректное число: ");
        }

        switch (op)
        {
            case "+":
                Console.WriteLine($"Результат: {num1 + num2}");
                break;
            case "-":
                Console.WriteLine($"Результат: {num1 - num2}");
                break;
            case "*":
                Console.WriteLine($"Результат: {num1 * num2}");
                break;
            case "/":
                if (num2 == 0)
                    Console.WriteLine("Ошибка: деление на ноль!");
                else
                    Console.WriteLine($"Результат: {num1 / num2}");
                break;
            default:
                Console.WriteLine("Неизвестная операция");
                break;
        }
    }
}