namespace Assignment4;

public class MyStack<T>
{
    private List<T> st = new List<T>();
    public int Count()
    {
        return st.Count;
    }
    public T Pop()
    {
        if (st.Count == 0)
        {
            Console.WriteLine("No elements are present");
            throw new Exception();
        }

        T top = st[st.Count() - 1];
        st.RemoveAt(st.Count() - 1);
        return top;

    }
    public void Push(T element)
    {
        st.Add(element);
    }
}