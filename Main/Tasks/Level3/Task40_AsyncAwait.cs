using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level3;

[TaskInfo(40, "async/await + обработка исключений",
    "Асинхронный метод с эмуляцией «скачивания».",
    "async Task<string> DownloadAsync(string url) — внутри Task.Delay(1000)",
    "Имитировать ошибку: если url пустой — бросить ArgumentException",
    "В Main вызвать через await внутри try/catch",
    "Продемонстрировать успешный и ошибочный вызов")]
public class Task40_AsyncAwait : ITask
{
    public void Run()
    {
        
        RunAsync().GetAwaiter().GetResult();
    }

    private async Task RunAsync()
    {
        Console.WriteLine("=== Тест 1: Успешное скачивание ===");
        try
        {
            Console.WriteLine("Начинаем скачивание...");
            string result = await DownloadAsync("https://example.com");
            Console.WriteLine($"Успех! {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine("\n=== Тест 2: Ошибочное скачивание (пустой URL) ===");
        try
        {
            Console.WriteLine("Начинаем скачивание...");
            string result = await DownloadAsync("");
            Console.WriteLine($"Успех! {result}");
        }
        catch (ArgumentException ex)
        {
            
            Console.WriteLine($"Поймано ожидаемое исключение: {ex.Message}");
        }
    }

    
    private async Task<string> DownloadAsync(string url)
    {
        
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("URL не может быть пустым", nameof(url));
        }

        
        await Task.Delay(1000);

        return $"Данные с {url} успешно загружены.";
    }
}
