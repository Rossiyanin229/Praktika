using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level3;

[TaskInfo(44, "Мини-проект «Todo List» (классы + JSON)",
    "Консольное приложение для списка задач с сохранением в JSON.",
    "Классы: TaskItem (Id, Title, IsDone), TaskRepository (CRUD), TaskService (бизнес-логика)",
    "CRUD-операции: добавить, вывести все, отметить выполненной, удалить",
    "Сохранение/загрузка через System.Text.Json (файл tasks.json)",
    "Меню с выбором действий",
    "Обработка ошибок (некорректный ввод, отсутствующий файл)")]
public class Task44_TodoList : ITask
{
    public void Run()
    {
        var repository = new TaskRepository("tasks.json");
        var service = new TaskService(repository);

        while (true)
        {
            Console.Clear();
            ConsoleHelper.PrintHeader("=== Todo List ===");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Показать все задачи");
            Console.WriteLine("3. Отметить задачу выполненной");
            Console.WriteLine("4. Удалить задачу");
            Console.WriteLine("0. Выход");
            Console.Write("\nВыберите действие: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите название задачи: ");
                    string title = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(title))
                    {
                        service.AddTask(title);
                        Console.WriteLine("Задача добавлена!");
                    }
                    else Console.WriteLine("Название не может быть пустым.");
                    break;
                case "2":
                    service.PrintAll();
                    break;
                case "3":
                    Console.Write("Введите ID задачи: ");
                    if (int.TryParse(Console.ReadLine(), out int idDone))
                    {
                        if (service.MarkAsDone(idDone)) Console.WriteLine("Задача выполнена!");
                        else Console.WriteLine("Задача с таким ID не найдена.");
                    }
                    else Console.WriteLine("Некорректный ID.");
                    break;
                case "4":
                    Console.Write("Введите ID задачи: ");
                    if (int.TryParse(Console.ReadLine(), out int idDel))
                    {
                        if (service.DeleteTask(idDel)) Console.WriteLine("Задача удалена!");
                        else Console.WriteLine("Задача с таким ID не найдена.");
                    }
                    else Console.WriteLine("Некорректный ID.");
                    break;
                case "0":
                    return; // Выход из задания
                default:
                    Console.WriteLine("Неверный пункт меню.");
                    break;
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }
    }
}
