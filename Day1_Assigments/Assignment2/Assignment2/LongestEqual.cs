namespace Assignment2;

public class LongestEqual
{
    public LongestEqual(int[] arr)
    {
        int start=0,end=-1;
        int count=1;
        int maxArray=0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                count++;
                if (maxArray < count)
                {
                    maxArray = count;
                    end = i;
                }
            }
            else
            {
                start = i;
                count = 1;
            }
        }

        for (int i = end; i > end - maxArray; i--)
        {
            Console.Write(arr[i] + " ");
        }

    }
}