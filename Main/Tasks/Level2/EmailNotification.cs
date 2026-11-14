using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"[EMAIL] Отправлено: {message}");
    }
}
