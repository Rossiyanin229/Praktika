using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;


public class Point : IEquatable<Point>
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    
    public bool Equals(Point? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        
        return X == other.X && Y == other.Y;
    }

   
    public override bool Equals(object? obj)
    {
        return Equals(obj as Point);
    }

    
    public override int GetHashCode()
    {
      
        return HashCode.Combine(X, Y);
    }

    public override string ToString() => $"({X}, {Y})";
}
