using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using Main.Common;

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
            Console.WriteLine("4. Выход");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Выберите уровень: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (input == "4" || input?.ToLower() == "q")
            {
                Console.WriteLine("Выход из программы...");
                break;
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
}