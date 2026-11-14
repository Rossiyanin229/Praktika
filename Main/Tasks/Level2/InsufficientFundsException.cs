using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;


public class InsufficientFundsException : Exception
{
    public decimal RequestedAmount { get; }
    public decimal CurrentBalance { get; }

    public InsufficientFundsException(decimal requestedAmount, decimal currentBalance)
        : base($"Недостаточно средств. Запрошено: {requestedAmount} руб., на счету: {currentBalance} руб.")
    {
        RequestedAmount = requestedAmount;
        CurrentBalance = currentBalance;
    }
}