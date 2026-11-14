using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Main.Common;

namespace Main.Tasks.Level3;

[TaskInfo(38, "List<T> vs LinkedList<T> (бенчмарк)",
    "Сравнить вставку в середину List<T> и LinkedList<T>.",
    "Создать List<int> и LinkedList<int> по 100 000 элементов",
    "Вставить 1000 элементов в середину каждой коллекции",
    "Замерить время через Stopwatch",
    "Вывести оба времени и объяснить результат в комментарии")]
public class Task38_ListVsLinkedList : ITask
{
    public void Run()
    {
        const int size = 100_000;
        const int insertCount = 1_000;

        Console.WriteLine($"Создание коллекций по {size} элементов...");

    
        List<int> list = new List<int>(size);
        for (int i = 0; i < size; i++) list.Add(i);

        LinkedList<int> linkedList = new LinkedList<int>();
        for (int i = 0; i < size; i++) linkedList.AddLast(i);

       
        LinkedListNode<int> middleNode = linkedList.Find(size / 2)!;

        Console.WriteLine("Начинаем вставку...\n");

       
        Stopwatch swList = Stopwatch.StartNew();
        for (int i = 0; i < insertCount; i++)
        {
          
            list.Insert(size / 2, i);
        }
        swList.Stop();

        
        Stopwatch swLinkedList = Stopwatch.StartNew();
        for (int i = 0; i < insertCount; i++)
        {
           
            linkedList.AddAfter(middleNode, i);
        }
        swLinkedList.Stop();

       
        Console.WriteLine($"List<T> вставка {insertCount} элементов:      {swList.ElapsedMilliseconds} мс");
        Console.WriteLine($"LinkedList<T> вставка {insertCount} элементов: {swLinkedList.ElapsedMilliseconds} мс");
        Console.WriteLine($"Разница: {swList.ElapsedMilliseconds - swLinkedList.ElapsedMilliseconds} мс");

        /*
          ПОЧЕМУ LINKEDLIST БЫСТРЕЕ НА ВСТАВКЕ В СЕРЕДИНУ?
          
          1. List<T> внутри хранит обычный массив. Когда ты вставляешь элемент в середину,
             ему нужно сдвинуть ВСЕ элементы после этой позиции на один шаг вправо.
             При 100 000 элементов это 50 000 сдвигов на каждую вставку!
          
          2. LinkedList<T> хранит элементы в виде узлов, где каждый узел знает ссылку на следующий.
             Чтобы вставить элемент в середину, нужно просто поменять 2-3 ссылки (указателя),
             не трогая остальные элементы. Это O(1), если у тебя уже есть нужный узел.
         
          НО: LinkedList медленнее на поиске по индексу (ему нужно перебрать все узлы с начала),
          и он занимает больше памяти (каждый узел хранит ссылки вперед/назад).
         */
    }
}
