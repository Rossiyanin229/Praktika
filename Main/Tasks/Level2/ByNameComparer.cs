using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;


public class ByNameComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x == null || y == null) return 0;

        
        return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
    }
}
