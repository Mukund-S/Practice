namespace Assignment2;
using System;
using System.Linq;

public class RotatedArray
{
    public RotatedArray(int[] array, int k)
    {
        int n = array.Length;
        int[] sum = new int[n];
        for (int r = 1; r <= k; r++)
        {
            int[] rotated = RotateRight(array, r);
            Console.WriteLine($"rotated{r}[] = {string.Join(" ", rotated)}");
            for (int i = 0; i < n; i++)
            {
                sum[i] += rotated[i];
            }
        }
        Console.WriteLine("sum[] = " + string.Join(" ", sum));
    }
        
    static int[] RotateRight(int[] array, int r)
    {
        int n = array.Length;
        int[] rotated = new int[n];
        for (int i = 0; i < n; i++)
        {
            rotated[(i + r) % n] = array[i];
        }
        return rotated;
    }
}