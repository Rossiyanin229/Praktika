using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(28, "Equals / GetHashCode для Point",
    "Переопределить Equals и GetHashCode для класса Point(x, y).",
    "Переопределить Equals(object) и GetHashCode()",
    "Реализовать IEquatable<Point>",
    "Проверить: две точки с одинаковыми координатами равны",
    "Проверить в HashSet<Point>: добавление дубликата не увеличивает Count")]
public class Task28_Equality : ITask
{
    public void Run()
    {
        Point p1 = new Point(10, 20);
        Point p2 = new Point(10, 20);
        Point p3 = new Point(5, 15);

        Console.WriteLine("=== Тест 1: Проверка Equals ===");
        Console.WriteLine($"p1 = {p1}, p2 = {p2}");
        Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}"); 
        Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
        Console.WriteLine();

        Console.WriteLine("=== Тест 2: Проверка HashSet ===");
        
        HashSet<Point> pointsSet = new HashSet<Point>();

        Console.WriteLine($"Добавляем p1. Count: {pointsSet.Add(p1)}"); 
        Console.WriteLine($"Добавляем p2 (дубликат). Count: {pointsSet.Add(p2)}"); 
        Console.WriteLine($"Добавляем p3. Count: {pointsSet.Add(p3)}"); 

        Console.WriteLine($"\nИтоговый размер HashSet: {pointsSet.Count}"); 
        Console.WriteLine("Содержимое HashSet:");
        foreach (var point in pointsSet)
        {
            Console.WriteLine(point);
        }
    }
}