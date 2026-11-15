using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Main.Common;

namespace Main.Tasks.Level3;

[TaskInfo(41, "Task.WhenAll — параллельно 10 задач",
    "Запустить 10 задач параллельно и сравнить с последовательным выполнением.",
    "Метод Task<int> WorkAsync(int id) — Task.Delay(500), возвращает id",
    "Последовательный запуск 10 задач в цикле с await",
    "Параллельный запуск через Task.WhenAll",
    "Замерить время обоих вариантов через Stopwatch",
    "Вывести оба времени и объяснить разницу")]
public class Task41_TaskWhenAll : ITask
{
    public void Run()
    {
        RunAsync().GetAwaiter().GetResult();
    }

    private async Task RunAsync()
    {
        const int taskCount = 10;

        
        Console.WriteLine("=== Последовательный запуск ===");
        Stopwatch swSequential = Stopwatch.StartNew();

        for (int i = 1; i <= taskCount; i++)
        {
            int result = await WorkAsync(i);
            Console.WriteLine($"Задача {result} завершена.");
        }
        swSequential.Stop();
        Console.WriteLine($"Время: {swSequential.ElapsedMilliseconds} мс\n");

        
        Console.WriteLine("=== Параллельный запуск (Task.WhenAll) ===");
        Stopwatch swParallel = Stopwatch.StartNew();

      
        List<Task<int>> tasks = new List<Task<int>>();
        for (int i = 1; i <= taskCount; i++)
        {
            tasks.Add(WorkAsync(i));
        }

        int[] results = await Task.WhenAll(tasks);

        swParallel.Stop();
        foreach (int result in results)
        {
            Console.WriteLine($"Задача {result} завершена.");
        }
        Console.WriteLine($"Время: {swParallel.ElapsedMilliseconds} мс\n");

        
        Console.WriteLine($"Последовательное: {swSequential.ElapsedMilliseconds} мс");
        Console.WriteLine($"Параллельное:     {swParallel.ElapsedMilliseconds} мс");
        Console.WriteLine($"Ускорение: в {swSequential.ElapsedMilliseconds / (double)Math.Max(1, swParallel.ElapsedMilliseconds):F1} раз");

        /*
          ПОЧЕМУ ПАРАЛЛЕЛЬНОЕ БЫСТРЕЕ?
          
          В последовательном варианте мы делаем `await` сразу внутри цикла.
          Программа "засыпает" на 500 мс, ждет задачу, потом запускает следующую.
          Общее время = 10 * 500 мс = 5000 мс.
          
          В параллельном варианте мы запускаем все задачи, не дожидаясь их.
          Они работают одновременно (параллельно). 
          Task.Delay просто ждет таймер, не занимая поток, поэтому все 10 таймеров
          срабатывают почти одновременно.
          Общее время = 500 мс.
         */
    }

    
    private async Task<int> WorkAsync(int id)
    {
        await Task.Delay(500);
        return id;
    }
}
