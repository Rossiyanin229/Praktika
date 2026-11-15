using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level3;

// Собственное исключение для демонстрации
public class MyCustomException : Exception
{
    public MyCustomException(string message) : base(message) { }
}

[TaskInfo(43, "Множественные типы исключений, порядок catch",
    "Продемонстрировать порядок обработки исключений.",
    "Метод, который может бросить FormatException, DivideByZeroException или свой CustomException",
    "Несколько catch-блоков в правильном порядке (от частного к общему)",
    "Продемонстрировать все три сценария",
    "В конце — finally с выводом «завершено»",
    "Объяснить в комментарии, почему порядок catch важен")]
public class Task43_ExceptionOrder : ITask
{
    public void Run()
    {
        
        TestScenario("abc");

       
        TestScenario("0");

       
        TestScenario("custom");

       
        TestScenario("10");
    }

    private void TestScenario(string input)
    {
        Console.WriteLine($"\n--- Ввод: \"{input}\" ---");
        try
        {
            int result = ParseAndDivide(input);
            Console.WriteLine($"Результат: {result}");
        }
        
        catch (FormatException ex)
        {
            Console.WriteLine($"Поймано FormatException: {ex.Message}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Поймано DivideByZeroException: {ex.Message}");
        }
        catch (MyCustomException ex)
        {
            Console.WriteLine($"Поймано MyCustomException: {ex.Message}");
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"Поймано неизвестное исключение: {ex.Message}");
        }
        finally
        {
         
            Console.WriteLine("Завершено.");
        }
    }

    private int ParseAndDivide(string input)
    {
        
        if (input == "custom")
            throw new MyCustomException("Это специально вызванная ошибка!");

       
        int number = int.Parse(input);

       
        return 100 / number;
    }
    //Почему порядок catch важен (объяснение):
   // В C# FormatException и DivideByZeroException наследуются от Exception. Если ты поставишь catch (Exception ex) первым, то он перехватит все исключения, и до специфичных блоков (FormatException и т.д.) дело просто не дойдет. Поэтому правило такое: от частного к общему
}
