using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;


public class BankAccount
{
  
    private decimal _balance;

    public BankAccount(decimal initialBalance = 0)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Начальный баланс не может быть отрицательным");

        _balance = initialBalance;
    }

    public decimal Balance => _balance;

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма пополнения должна быть больше нуля");

        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма снятия должна быть больше нуля");

        if (amount > _balance)
        {
            throw new InsufficientFundsException(amount, _balance);
        }

        _balance -= amount;
    }
}
