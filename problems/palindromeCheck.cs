
using System;

class Program
{
    static bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }


    static bool IsPalindromeByStringReverse(string s)
    {
        char[] chars = s.ToCharArray();
        Array.Reverse(chars);

        string reversed = new string(chars);

        return s == reversed;
    }


    static void Main()
    {
        Console.WriteLine(IsPalindrome("madam"));  
        Console.WriteLine(IsPalindrome("racecar"));
        Console.WriteLine(IsPalindrome("hello"));   
        Console.WriteLine(IsPalindrome("a"));      
        Console.WriteLine(IsPalindrome(""));       

        Console.Write("Enter a string:");
        string input = Console.ReadLine() ?? "";
        Console.WriteLine(IsPalindrome(input));

    }
}
