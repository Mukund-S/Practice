namespace Assignment2;

public class FindPrime
{
    public FindPrime()
    {
        Console.WriteLine("Get prime numbers from:");
        string number1=Console.ReadLine();
        int start = int.Parse(number1);
        Console.WriteLine("Get prime numbers to:");
        string number2=Console.ReadLine();
        int end = int.Parse(number2);
        int[] arr1 = FindPrimesInRange(start,end);
        Console.WriteLine($"Prime Numbers from {start} to {end}");
        for(int i=0;i<arr1.Length;i++)
            Console.WriteLine(arr1[i]);
    }
    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        int[] arr = new int[endNum-startNum+1];
        int index = 0;
        for (int i = startNum; i <= endNum; i++)
        {
            bool isPrime = true;
            if (i <= 1)
            {
                isPrime = false;
            }
            else
            {
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            
            }

            if (isPrime)
                arr[index++] = i;
        }
        Array.Resize(ref arr, index);
        return arr;
    }
}