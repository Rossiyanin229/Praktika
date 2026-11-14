using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(33, "LINQ: сотрудники (top-3, avg по отделу, фильтр)",
    "LINQ-запросы по списку сотрудников.",
    "Класс Employee: Name, Age, Salary, Department",
    "Список из 10+ сотрудников",
    "Запросы через LINQ: топ-3 по зарплате, средняя зарплата по каждому отделу (GroupBy + Average), сотрудники старше 30 (Where)",
    "Вывести результаты")]
public class Task33_LinqEmployees : ITask
{
    public void Run()
    {
       
        List<Employee> employees = new List<Employee>
        {
            new Employee("Иван", 25, 50000, "IT"),
            new Employee("Анна", 32, 75000, "HR"),
            new Employee("Сергей", 45, 120000, "IT"),
            new Employee("Мария", 28, 60000, "Finance"),
            new Employee("Дмитрий", 38, 90000, "IT"),
            new Employee("Елена", 29, 65000, "HR"),
            new Employee("Алексей", 42, 110000, "Finance"),
            new Employee("Ольга", 35, 80000, "IT"),
            new Employee("Павел", 27, 55000, "Sales"),
            new Employee("Наталья", 31, 70000, "Sales")
        };

        Console.WriteLine("=== Все сотрудники ===");
        foreach (var emp in employees) Console.WriteLine(emp);

        
        Console.WriteLine("\n=== Топ-3 по зарплате ===");
        var top3 = employees
            .OrderByDescending(e => e.Salary)
            .Take(3);
        foreach (var emp in top3) Console.WriteLine(emp);

       
        Console.WriteLine("\n=== Средняя зарплата по отделам ===");
        var avgByDept = employees
            .GroupBy(e => e.Department) 
            .Select(g => new
            {
                Department = g.Key,
                AverageSalary = g.Average(e => e.Salary)
            })
            .OrderByDescending(x => x.AverageSalary); 

        foreach (var item in avgByDept)
        {
            Console.WriteLine($"{item.Department,-10} : {item.AverageSalary:F2}");
        }

        
        Console.WriteLine("\n=== Сотрудники старше 30 ===");
        var over30 = employees
            .Where(e => e.Age > 30)
            .OrderBy(e => e.Age); 
        foreach (var emp in over30) Console.WriteLine(emp);
    }
}
