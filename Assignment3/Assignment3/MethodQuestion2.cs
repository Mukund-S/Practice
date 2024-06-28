namespace Assignment3;

public class MethodQuestion2
{
    public MethodQuestion2()
    {
        Console.Write("\nPrint Fibonacci Sequence: ");
        for (int i = 1; i <= 10; i++)
        {
            Console.Write(Fibonacci(i)+" ");
        }
    }

    public int Fibonacci(int n)
    {
        if (n == 1 || n == 2)
            return 1;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}