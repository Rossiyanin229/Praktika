using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;

public abstract class Animal
{
    public string Name { get; set; }

    protected Animal(string name)
    {
        Name = name;
    }

   
    public abstract string MakeSound();

        
    public override string ToString()
    {
        return $"{GetType().Name} по имени {Name} говорит: {MakeSound()}";
    }
}
