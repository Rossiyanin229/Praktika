using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level3;

[TaskInfo(45, "Мини-проект «Библиотека» + юнит-тесты",
    "Классы библиотеки + тесты.",
    "Классы: Book (Title, Author, IsAvailable), Reader (Name, BorrowedBooks), Library (выдача/возврат)",
    "Логика: выдача книги читателю, возврат, лимит (не больше 3 книг на читателя)",
    "Обработка: книгу уже выдали, лимит превышен — бросать исключения",
    "Написать 5+ юнит-тестов (xUnit/NUnit) на ключевые сценарии",
    "Все тесты должны проходить")]
public class Task45_Library : ITask
{
    public void Run()
    {
        Console.WriteLine("Задание 45: Мини-проект «Библиотека».");
        Console.WriteLine("Логика библиотеки реализована в классах Book, Reader, Library.");
        Console.WriteLine("Юнит-тесты находятся в отдельном проекте 'Practicum.Tests'.");
        Console.WriteLine("Чтобы запустить тесты, откройте 'Обозреватель тестов' в Visual Studio и нажмите 'Запустить все'.");
    }
}
