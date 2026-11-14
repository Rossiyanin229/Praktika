using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(25, "Интерфейс IShape + сортировка фигур",
    "Реализовать интерфейс фигур и отсортировать их.",
    "IShape с методами Area() и Perimeter()",
    "Классы Circle, Rectangle, Triangle — реализуют IShape",
    "Создать List<IShape> из 5+ фигур",
    "Отсортировать по площади (через List.Sort с лямбдой или OrderBy)",
    "Вывести фигуры с площадями до и после сортировки")]
public class Task25_Shapes : ITask
{
    public void Run()
    {
        List<IShape> shapes = new List<IShape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5),
            new Circle(2),
            new Rectangle(10, 2)
        };

        Console.WriteLine("=== До сортировки ===");
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape);
        }

        
        shapes.Sort((s1, s2) => s1.Area().CompareTo(s2.Area()));

        Console.WriteLine("\n=== После сортировки (по возрастанию площади) ===");
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape);
        }
    }
}