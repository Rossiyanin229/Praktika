using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Common;


public static class ConsoleHelper
{
    public static void PrintHeader(string title)
    {
        Console.WriteLine(new string('=', 50));
        Console.WriteLine(title);
        Console.WriteLine(new string('-', 50));
    }
}