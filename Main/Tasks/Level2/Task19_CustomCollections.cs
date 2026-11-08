using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(19, "Свой стек/очередь на массиве",
    "Реализовать MyStack<T> и MyQueue<T> на массиве.",
    "Стек: Push, Pop, Peek, Count, IsEmpty",
    "Очередь: Enqueue, Dequeue, Peek, Count, IsEmpty",
    "При переполнении — расширять внутренний массив (удвоение)",
    "Pop/Dequeue на пустой коллекции — бросать InvalidOperationException")]
public class Task19_CustomCollections : ITask
{
    public void Run()
    {
        Console.WriteLine("=== ТЕСТ СТЕКА (MyStack) ===");
        MyStack<int> stack = new MyStack<int>(2);

        stack.Push(10);
        stack.Push(20);
        stack.Push(30); 
        Console.WriteLine($"Count: {stack.Count}"); 
        Console.WriteLine($"Peek: {stack.Peek()}"); 
        Console.WriteLine($"Pop: {stack.Pop()}"); 
        Console.WriteLine($"Pop: {stack.Pop()}"); 
        Console.WriteLine($"Count после Pop: {stack.Count}");

        try
        {
            stack.Pop(); 
            stack.Pop(); 
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ожидаемая ошибка: {ex.Message}");
        }

        Console.WriteLine("\n=== ТЕСТ ОЧЕРЕДИ (MyQueue) ===");
        MyQueue<string> queue = new MyQueue<string>(2);

        queue.Enqueue("A");
        queue.Enqueue("B");
        queue.Enqueue("C");
        Console.WriteLine($"Count: {queue.Count}"); 
        Console.WriteLine($"Peek: {queue.Peek()}"); 
        Console.WriteLine($"Dequeue: {queue.Dequeue()}"); 
        Console.WriteLine($"Dequeue: {queue.Dequeue()}"); 
        Console.WriteLine($"Count после Dequeue: {queue.Count}"); 

        try
        {
            queue.Dequeue(); 
            queue.Dequeue(); 
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ожидаемая ошибка: {ex.Message}");
        }
    }
}