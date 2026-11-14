using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(14, "Возраст по дате рождения",
    "По дате рождения вычислить точный возраст в годах, месяцах и днях.",
    "Ввод даты через DateTime.TryParse",
    "Учесть, что день рождения в этом году мог ещё не наступить",
    "Вывести «X лет, Y месяцев, Z дней»",
    "Некорректная дата — сообщение об ошибке, не падать")]
public class Task14_AgeCalculator : ITask
{
    public void Run()
    {
        Console.Write("Введите дату рождения (например, 15.05.1990): ");
        string input = Console.ReadLine()!;

        
        if (!DateTime.TryParse(input, out DateTime birthDate))
        {
            Console.WriteLine("Ошибка: некорректный формат даты.");
            return;
        }

        
        if (birthDate > DateTime.Today)
        {
            Console.WriteLine("Ошибка: дата рождения не может быть в будущем.");
            return;
        }

        
        DateTime today = DateTime.Today;

        int years = today.Year - birthDate.Year;
        int months = today.Month - birthDate.Month;
        int days = today.Day - birthDate.Day;

        
        if (today.Month < birthDate.Month || (today.Month == birthDate.Month && today.Day < birthDate.Day))
        {
            years--;
        }

        
        if (days < 0)
        {
            months--;
            
            DateTime prevMonth = today.AddMonths(-1);
            days += DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);
        }

        
        if (months < 0)
        {
            months += 12;
        }

        Console.WriteLine($"\nВаш возраст: {years} лет, {months} месяцев, {days} дней.");
    }
}
