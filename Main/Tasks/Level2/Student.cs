using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;


public class Student : IComparable<Student>
{
    public string Name { get; set; }
    public double AverageGrade { get; set; }

    public Student(string name, double averageGrade)
    {
        Name = name;
        AverageGrade = averageGrade;
    }

    
    public int CompareTo(Student? other)
    {
        if (other == null) return 1;

        
        return other.AverageGrade.CompareTo(this.AverageGrade);
    }

    public override string ToString()
    {
        return $"{Name,-15} | Средний балл: {AverageGrade:F2}";
    }
}
