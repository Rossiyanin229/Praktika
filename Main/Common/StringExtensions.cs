using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Common;


public static class StringExtensions
{
   
    public static bool IsPalindrome(this string str)
    {
        if (string.IsNullOrEmpty(str)) return true;

        string cleaned = "";
        foreach (char c in str.ToLower())
        {
            if (char.IsLetterOrDigit(c)) cleaned += c;
        }

        int left = 0, right = cleaned.Length - 1;
        while (left < right)
        {
            if (cleaned[left] != cleaned[right]) return false;
            left++;
            right--;
        }
        return true;
    }

    
    public static int WordCount(this string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return 0;

        
        string[] words = str.Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '-', '\n', '\r' },
                                   StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    
    public static string ReverseString(this string str)
    {
        if (string.IsNullOrEmpty(str)) return str;

        char[] chars = new char[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            chars[i] = str[str.Length - 1 - i];
        }
        return new string(chars);
    }
}