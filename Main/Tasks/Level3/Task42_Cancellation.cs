using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Main.Common;

namespace Main.Tasks.Level3;

[TaskInfo(42, "CancellationToken — отмена через 2 сек",
    "Реализовать долгую операцию с поддержкой отмены.",
    "async Task LongOperationAsync(CancellationToken token) — цикл с Task.Delay(500, token) 10 раз",
    "В Main создать CancellationTokenSource, запустить операцию, отменить через 2 секунды",
    "Обработать OperationCanceledException",
    "Вывести «операция отменена»")]
public class Task42_Cancellation : ITask
{
    public void Run()
    {
        RunAsync().GetAwaiter().GetResult();
    }

    private async Task RunAsync()
    {
        Console.WriteLine("Запуск долгой операции (10 шагов по 500 мс)...");

       
        using CancellationTokenSource cts = new CancellationTokenSource();

      
        cts.CancelAfter(TimeSpan.FromSeconds(2));

        try
        {
          
            await LongOperationAsync(cts.Token);
            Console.WriteLine("Операция завершилась успешно (дошла до конца).");
        }
        catch (OperationCanceledException)
        {
           
            Console.WriteLine("\n!!! Операция отменена по таймауту (2 секунды) !!!");
        }
    }

    private async Task LongOperationAsync(CancellationToken token)
    {
        for (int i = 1; i <= 10; i++)
        {
            
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"Шаг {i}/10 выполнен.");

            
            await Task.Delay(500, token);
        }
    }
}
