using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(35, "Git: .gitignore, PR, Conventional Commits, rebase",
    "Пройти продвинутый git-сценарий.",
    "Добавить .gitignore и .editorconfig отдельным коммитом",
    "Создать ветку feature/task-35, сделать 2–3 коммита",
    "Открыть Pull Request в main и смержить",
    "Выполнить rebase -i и сохранить вывод в git-notes.md")]
public class Task35_GitAdvanced : ITask
{
    public void Run()
    {
        Console.WriteLine("Это задание выполнено через Git (PR, rebase).");
        Console.WriteLine("Подробности в файле git-notes.md");
    }
}