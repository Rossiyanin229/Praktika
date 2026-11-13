using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;

public class Triangle : IShape
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    public Triangle(double a, double b, double c)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    public string Name => "Треугольник";

    public double Area()
    {
     
        double p = Perimeter() / 2;
        return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
    }

    public double Perimeter() => _a + _b + _c;

    public override string ToString() => $"{Name} ({_a},{_b},{_c}): Площадь = {Area():F2}, Периметр = {Perimeter():F2}";
}