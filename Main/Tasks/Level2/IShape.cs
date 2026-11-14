using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;

public interface IShape
{
    double Area();
    double Perimeter();
    string Name { get; }
}
