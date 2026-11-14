using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level3;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }

    public override string ToString()
    {
        string status = IsDone ? "[x]" : "[ ]";
        return $"{Id,3}. {status} {Title}";
    }
}
