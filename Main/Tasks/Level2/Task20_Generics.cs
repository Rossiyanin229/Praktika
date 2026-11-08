using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(20, "Обобщения: Swap<T>, Max<T> с IComparable<T>",
    "Написать обобщённые методы.",
    "Swap<T>(ref T a, ref T b) — меняет значения местами",
    "Max<T>(T a, T b) where T : IComparable<T> — возвращает большее",
    "Продемонстрировать на int, string, double",
    "Swap — без ограничений, Max — с ограничением")]
public class Task20_Generics : ITask
{
    public void Run()
    {
        
        int a = 5, b = 10;
        Console.WriteLine($"До Swap: a={a}, b={b}");
        Swap(ref a, ref b);
        Console.WriteLine($"После Swap: a={a}, b={b}");
        Console.WriteLine($"Max(5, 10) = {Max(5, 10)}\n");

        
        string s1 = "Apple", s2 = "Banana";
        Console.WriteLine($"До Swap: s1={s1}, s2={s2}");
        Swap(ref s1, ref s2);
        Console.WriteLine($"После Swap: s1={s1}, s2={s2}");
        
        Console.WriteLine($"Max(\"Apple\", \"Banana\") = {Max("Apple", "Banana")}\n");

       
        double d1 = 3.14, d2 = 2.71;
        Console.WriteLine($"До Swap: d1={d1}, d2={d2}");
        Swap(ref d1, ref d2);
        Console.WriteLine($"После Swap: d1={d1}, d2={d2}");
        Console.WriteLine($"Max(3.14, 2.71) = {Max(3.14, 2.71)}");
    }

   
    private void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    
    private T Max<T>(T a, T b) where T : IComparable<T>
    {
        
        if (a.CompareTo(b) > 0)
            return a;
        else
            return b;
    }
}