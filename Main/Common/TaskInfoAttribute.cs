using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Common;


[AttributeUsage(AttributeTargets.Class)]
public class TaskInfoAttribute : Attribute
{
    public int Number { get; }
    public string Title { get; }
    public string Description { get; }
    public string[] Requirements { get; }

    public TaskInfoAttribute(int number, string title, string description, params string[] requirements)
    {
        Number = number;
        Title = title;
        Description = description;
        Requirements = requirements;
    }
}
