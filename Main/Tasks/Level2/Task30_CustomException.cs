using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(30, "BankAccount + свой Exception",
    "Реализовать банковский счёт с собственным исключением.",
    "Класс BankAccount с приватным балансом",
    "Методы Deposit(decimal), Withdraw(decimal)",
    "Свой класс InsufficientFundsException : Exception",
    "Withdraw бросает исключение, если сумма больше баланса",
    "Продемонстрировать: успешное снятие и попытку снять больше баланса (с try/catch)")]
public class Task30_CustomException : ITask
{
    public void Run()
    {
        BankAccount account = new BankAccount(1000);

        Console.WriteLine($"Начальный баланс: {account.Balance} руб.\n");

        
        Console.WriteLine("--- Попытка снять 400 руб. ---");
        try
        {
            account.Withdraw(400);
            Console.WriteLine($"Успех! Новый баланс: {account.Balance} руб.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

       
        Console.WriteLine("\n--- Попытка снять 1000 руб. (баланс 600) ---");
        try
        {
            account.Withdraw(1000);
            Console.WriteLine($"Успех! Новый баланс: {account.Balance} руб.");
        }
        catch (InsufficientFundsException ex)
        {
          
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"  Запрошено: {ex.RequestedAmount}");
            Console.WriteLine($"  Доступно: {ex.CurrentBalance}");
        }

        Console.WriteLine($"\nИтоговый баланс: {account.Balance} руб. (не ушел в минус)");
    }
}
