namespace Assignment2;

public class CopyingArray
{
    public int[] arr2 = new int[10];
    public CopyingArray(int[] arr1){
        int n = arr1.Length;
        for (int i = 0; i < n; i++)
        {
            arr2[i] = arr1[i];
        }
        Console.Write("Elements of Array 1: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr1[i] + " ");
        }
        Console.Write("\nElements of Array 2: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr2[i] + " ");
        }
    }
}