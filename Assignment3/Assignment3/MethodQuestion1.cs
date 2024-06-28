namespace Assignment3;

public class MethodQuestion1
{
    public MethodQuestion1()
    {
        int[] numbers = GenerateNumbers();
        Reverse(numbers);
        PrintNumbers(numbers);
    }
    public int[] GenerateNumbers()
    {
        int[] arr = new int[10];
        for (int i = 0; i < 10; i++)
        {
            arr[i] = i + 1;
        }
        return arr;
    }

    public int[] Reverse(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n / 2; i++)
        {
            int temp = arr[i];
            arr[i] = arr[n - i - 1];
            arr[n - i - 1] = temp;
        }
        return arr;
    }

    public void PrintNumbers(int[] arr)
    {
        Console.Write("Revered array: ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        }
    }
}