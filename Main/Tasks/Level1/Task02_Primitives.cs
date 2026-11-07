using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(2, "Переменные примитивных типов",
    "Объявить переменные всех примитивных типов и вывести их значения и типы.",
    "Минимум: int, long, double, float, decimal, bool, char, string",
    "Для каждой вывести значение и GetType().Name",
    "decimal — с суффиксом m, float — с f")]
public class Task02_Primitives : ITask
{
    public void Run()
    {
        int myInt = 42;
        long myLong = 1234567890123L;
        double myDouble = 3.14159;
        float myFloat = 2.5f; 
        decimal myDecimal = 19.99m;
        bool myBool = true;
        char myChar = 'A';
        string myString = "Привет";

        Console.WriteLine($"int = {myInt} ({myInt.GetType().Name})");
        Console.WriteLine($"long = {myLong} ({myLong.GetType().Name})");
        Console.WriteLine($"double = {myDouble} ({myDouble.GetType().Name})");
        Console.WriteLine($"float = {myFloat} ({myFloat.GetType().Name})");
        Console.WriteLine($"decimal = {myDecimal} ({myDecimal.GetType().Name})");
        Console.WriteLine($"bool = {myBool} ({myBool.GetType().Name})");
        Console.WriteLine($"char = {myChar} ({myChar.GetType().Name})");
        Console.WriteLine($"string = {myString} ({myString.GetType().Name})");
    }
}