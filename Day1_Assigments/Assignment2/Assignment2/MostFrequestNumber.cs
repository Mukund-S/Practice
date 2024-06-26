namespace Assignment2;

public class MostFrequestNumber
{
    public MostFrequestNumber(int[] arr)
    {
        int n=arr.Length;
        int m=0;
        int c = 1;
        int ele = 0;
        Array.Sort(arr);
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                c++;
                if (c > m)
                {
                    m = c;
                    ele = arr[i];
                }
            }
            else
            {
                c = 1;
            }
        }
        Console.WriteLine($"Element with maximum frequency {ele}");
    }
}