namespace Assignment2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
public class AllPalindrome
{
    public AllPalindrome(string text){
      
        var palindromes = ExtractPalindromes(text);
        Console.WriteLine("Palindromes:");
        Console.WriteLine(string.Join(", ", palindromes));
    }
    static IEnumerable<string> ExtractPalindromes(string text)
    {
        string pattern = @"\w+";
        Regex regex = new Regex(pattern);
        var matches = regex.Matches(text);
        HashSet<string> uniquePalindromes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (Match match in matches)
        {
            string word = match.Value;
            if (IsPalindrome(word))
            {
                uniquePalindromes.Add(word);
            }
        }
        return uniquePalindromes.OrderBy(p => p, StringComparer.OrdinalIgnoreCase);
    }
    static bool IsPalindrome(string word)
    {
        int left = 0;
        int right = word.Length - 1;
        while (left < right)
        {
            if (char.ToLower(word[left]) != char.ToLower(word[right]))
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}