using System.ComponentModel;

namespace Assignment4;

public class GenericList<T>
{
    private List<T> lt = new List<T>();

    public void Add(T element)
    {
        lt.Add(element);
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= lt.Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }
        T val = lt[index];
        lt.RemoveAt(index);
        return val;
    }

    public bool Contains(T element)
    {
        return lt.Contains(element); 
    }

    public void Clear()
    {
        lt.Clear();
    }

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > lt.Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }
        lt.Insert(index,element);
    }

    public void DeleteAt(int index)
    {
        if (index < 0 || index > lt.Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }
        lt.RemoveAt(index);
    }

    public T Find(int index)
    {
        if (index < 0 || index > lt.Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        T element = lt[index];
        return element;
    }
    
}