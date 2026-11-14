using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;

public class Rectangle : IShape
{
    private readonly double _width;
    private readonly double _height;

    public Rectangle(double width, double height)
    {
        _width = width;
        _height = height;
    }

    public string Name => "Прямоугольник";

    public double Area() => _width * _height;

    public double Perimeter() => 2 * (_width + _height);

    public override string ToString() => $"{Name} ({_width}x{_height}): Площадь = {Area():F2}, Периметр = {Perimeter():F2}";
}
