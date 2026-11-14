using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;


public class MyStack<T>
{
    private T[] _items;
    private int _count;

    public MyStack(int capacity = 4)
    {
        _items = new T[capacity];
        _count = 0;
    }

    public int Count => _count;
    public bool IsEmpty => _count == 0;

    public void Push(T item)
    {
        if (_count == _items.Length)
        {
            Resize();
        }
        _items[_count] = item;
        _count++;
    }

    public T Pop()
    {
        if (IsEmpty) throw new InvalidOperationException("Стек пуст");

        T item = _items[_count - 1];
        _items[_count - 1] = default!;
        _count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Стек пуст");
        return _items[_count - 1];
    }

    private void Resize()
    {
        
        T[] newArray = new T[_items.Length * 2];
        Array.Copy(_items, newArray, _items.Length);
        _items = newArray;
    }
}
