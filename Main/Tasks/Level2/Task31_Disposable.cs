using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(31, "IDisposable + using",
    "Реализовать IDisposable для класса, работающего с файлом.",
    "Класс FileWriter с полем StreamWriter",
    "Реализовать Dispose() (закрыть StreamWriter)",
    "Продемонстрировать использование через using",
    "Дополнительно: продемонстрировать using-декларацию (C# 8+, using var)")]
public class Task31_Disposable : ITask
{
    public void Run()
    {
        string filePath = "test_file.txt";

        Console.WriteLine("=== Способ 1: Классический блок using ===");
        
        using (FileWriter writer = new FileWriter(filePath))
        {
            writer.WriteLine("Строка 1: Привет!");
            writer.WriteLine("Строка 2: Как дела?");
        } 

        Console.WriteLine("Файл записан и закрыт (Способ 1).\n");

        
        if (File.Exists(filePath))
        {
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(File.ReadAllText(filePath));
        }

        Console.WriteLine("=== Способ 2: using-декларация (C# 8+) ===");
    
        using var writer2 = new FileWriter("test_file2.txt");
        writer2.WriteLine("Это using-декларация.");
        Console.WriteLine("Файл 2 записан. (Закроется при выходе из метода)");

        
      //  File.Delete(filePath);
      //  File.Delete("test_file2.txt");
    }
}
