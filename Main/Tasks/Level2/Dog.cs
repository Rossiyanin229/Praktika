using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;

public class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override string MakeSound()
    {
        return "Гав-гав!";
    }
}
