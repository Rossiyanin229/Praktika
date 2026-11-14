using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(27, "IComparable / IComparer<T> для Student",
    "Научить Student сортироваться.",
    "Класс Student: Name, AverageGrade",
    "Реализовать IComparable<Student> — сортировка по среднему баллу (по убыванию)",
    "Реализовать IComparer<Student> ByNameComparer — сортировка по имени",
    "Продемонстрировать обе сортировки на List<Student>")]
public class Task27_SortingStudents : ITask
{
    public void Run()
    {
        List<Student> students = new List<Student>
        {
            new Student("Анна", 4.8),
            new Student("Борис", 3.5),
            new Student("Виктор", 4.2),
            new Student("Дмитрий", 5.0),
            new Student("Елена", 4.1)
        };

        Console.WriteLine("=== Исходный список ===");
        foreach (var s in students) Console.WriteLine(s);

        Console.WriteLine("\n=== Сортировка по среднему баллу (IComparable) ===");
        students.Sort(); 
        foreach (var s in students) Console.WriteLine(s);

        Console.WriteLine("\n=== Сортировка по имени (IComparer) ===");
        students.Sort(new ByNameComparer()); 
        foreach (var s in students) Console.WriteLine(s);
    }
}
