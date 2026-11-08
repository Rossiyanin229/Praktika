using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;


public enum DayOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

[TaskInfo(21, "enum дни недели",
    "Описать дни недели через enum и определить тип дня.",
    "enum DayOfWeek { Monday, ..., Sunday }",
    "Метод IsWeekend(DayOfWeek day) — true для субботы и воскресенья",
    "Метод GetRussianName(DayOfWeek day) — возвращает название на русском",
    "Продемонстрировать на всех 7 днях")]
public class Task21_Weekdays : ITask
{
    public void Run()
    {
        
        Array days = Enum.GetValues(typeof(DayOfWeek));

        foreach (DayOfWeek day in days)
        {
            
            string name = GetRussianName(day);
            bool isWeekend = IsWeekend(day);

            Console.WriteLine($"{day,-10} | Русское название: {name,-12} | Выходной: {isWeekend}");
        }
    }

    private bool IsWeekend(DayOfWeek day)
    {
        
        return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
    }

    private string GetRussianName(DayOfWeek day)
    {
       
        return day switch
        {
            DayOfWeek.Monday => "Понедельник",
            DayOfWeek.Tuesday => "Вторник",
            DayOfWeek.Wednesday => "Среда",
            DayOfWeek.Thursday => "Четверг",
            DayOfWeek.Friday => "Пятница",
            DayOfWeek.Saturday => "Суббота",
            DayOfWeek.Sunday => "Воскресенье",
            _ => "Неизвестно"
        };
    }
}
