namespace Assignment2;
using System.Text.RegularExpressions;
public class ReverseWord
{
    public ReverseWord(string str)
    {
        string pattern = @"([.,:;=()&\[\]""'\\\/!? ]+)";
        Regex reg= new Regex(pattern);
        string[] token = reg.Split(str);
        Array.Reverse(token);
        string ans = string.Concat(token);
        Console.WriteLine(ans);
    }
}