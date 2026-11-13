using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(24, "ООП: Animal → Dog/Cat/Bird",
    "Построить иерархию животных.",
    "Абстрактный класс Animal: свойство Name, абстрактный метод MakeSound(), переопределённый ToString()",
    "Классы Dog, Cat, Bird — наследники, реализуют MakeSound()",
    "Bird дополнительно имеет метод Fly()",
    "Продемонстрировать полиморфизм: List<Animal> с разными животными, вызов MakeSound() в цикле")]
public class Task24_Inheritance : ITask
{
    public void Run()
    {
       
        List<Animal> animals = new List<Animal>
        {
            new Dog("Шарик"),
            new Cat("Мурка"),
            new Bird("Кеша"),
            new Dog("Бобик")
        };

        Console.WriteLine("=== Полиморфизм в действии ===");
        foreach (Animal animal in animals)
        {
            
            Console.WriteLine(animal.ToString());
        }

        Console.WriteLine("\n=== Проверка уникального метода Bird ===");
        
        foreach (Animal animal in animals)
        {
            if (animal is Bird bird)
            {
                bird.Fly();
            }
        }
    }
}