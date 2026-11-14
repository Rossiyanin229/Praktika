using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;

public class Bird : Animal
{
    public Bird(string name) : base(name) { }

    public override string MakeSound()
    {
        return "Чирик!";
    }

    
    public void Fly()
    {
        Console.WriteLine($"{Name} летит в небо!");
    }
}