using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;

public class Circle : IShape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        _radius = radius;
    }

    public string Name => "Круг";

    public double Area() => Math.PI * _radius * _radius;

    public double Perimeter() => 2 * Math.PI * _radius;

    public override string ToString() => $"{Name} (r={_radius}): Площадь = {Area():F2}, Периметр = {Perimeter():F2}";
}
