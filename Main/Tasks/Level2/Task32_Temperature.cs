using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(32, "Свойства с валидацией (Temperature)",
    "Класс Temperature с валидацией в set.",
    "Свойство Celsius с проверкой в set: не ниже -273.15",
    "При некорректном значении — бросать ArgumentOutOfRangeException",
    "Вычисляемое свойство Fahrenheit (только get)",
    "Продемонстрировать корректное и некорректное присваивание")]
public class Task32_Temperature : ITask
{
    public void Run()
    {
        Console.WriteLine("=== Тест 1: Корректные значения ===");
        try
        {
            Temperature temp1 = new Temperature(25.0);
            Console.WriteLine($"Создано: {temp1.Celsius}°C = {temp1.Fahrenheit:F2}°F");

            
            temp1.Celsius = 100.0;
            Console.WriteLine($"Изменено: {temp1.Celsius}°C = {temp1.Fahrenheit:F2}°F");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine("\n=== Тест 2: Некорректное значение ===");
        try
        {
            Temperature temp2 = new Temperature(-300.0); 
            Console.WriteLine($"Создано: {temp2.Celsius}°C");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Поймано ожидаемое исключение: {ex.Message}");
        }

        Console.WriteLine("\n=== Тест 3: Изменение на некорректное значение ===");
        Temperature temp3 = new Temperature(20.0);
        try
        {
            temp3.Celsius = -500.0; 
            Console.WriteLine($"Новое значение: {temp3.Celsius}°C");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Поймано исключение: {ex.Message}");
            Console.WriteLine($"Значение осталось прежним: {temp3.Celsius}°C");
        }
    }
}
