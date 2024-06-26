namespace Assignment2;
using System.Text;
public class StringReversal
{
    public StringReversal(string str)
    {
        StringBuilder str1 = new StringBuilder();
        for (int i = str.Length - 1; i >= 0; i--)
        {
            str1.Append(str[i]);
        }
        string val = str1.ToString();
        Console.WriteLine($"Reversed String is: {val}");
    }
}