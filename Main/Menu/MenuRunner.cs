using Main.Common;
using Main.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Main.Menu;

public class MenuRunner
{
    public void Run()
    {
        while (true)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            ConsoleHelper.PrintHeader("=== Практикум по C# ===");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2. Уровень 2 — Средний (задания 16–35)");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Уровень 3 — Продвинутый (задания 36–50)");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("4. Базы данных (SQL)");
            Console.WriteLine("5. Выход");
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Выберите уровень: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (input == "5" || input?.ToLower() == "q")
            {
                Console.WriteLine("Выход из программы...");
                break;
            }
            else if (input == "4")
            {
                RunDatabaseMenu();
            }
            else if (input == "1" || input == "2" || input == "3")
            {
                int level = int.Parse(input);
                LevelMenu levelMenu = new LevelMenu(level);
                levelMenu.Show();
            }
            else
            {
                Console.WriteLine("\nНеверный ввод. Нажмите Enter и попробуйте снова...");
                Console.ReadLine();
            }
        }
    }                   

        private void RunDatabaseMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            ConsoleHelper.PrintHeader("=== Базы данных (SQL) ===");
            Console.ResetColor();

            Console.WriteLine("1. Задание 28: C# + SQL (SELECT)");
            Console.WriteLine("2. Задание 29: C# + SQL (INSERT)");
            Console.WriteLine("3. Задание 30: C# + SQL (Отчёт)");
            Console.WriteLine("0. Назад");
            Console.WriteLine();
            Console.Write("Выберите задание: ");

            string? input = Console.ReadLine();
            if (input == "0") break;

            if (input == "1")
            {
               
                var taskType = typeof(Task28_SqlSelect); 
                var instance = (ITask)Activator.CreateInstance(taskType)!;
                instance.Run();
            }
            else
            {
                Console.WriteLine("\n[Задание в разработке...]");
            }

            Console.WriteLine("\nНажмите Enter для возврата...");
            Console.ReadLine();
        }
    }
}


