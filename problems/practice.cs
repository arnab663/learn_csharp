
using System;

class Program
{
    // 1. Exact string comparison
    static bool IsPalindrome(string? s)
    {
        if (s is null)
            return false;

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
                return false;

            left++;
            right--;
        }

        return true;
    }

    // 2. Case-insensitive comparison
    static bool IsPalindromeIgnoreCase(string? s)
    {
        if (s is null)
            return false;

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (char.ToUpperInvariant(s[left]) !=
                char.ToUpperInvariant(s[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    // 3. Ignore punctuation, spaces, and letter case
    static bool IsPalindromeAlphanumeric(string? s)
    {
        if (s is null)
            return false;

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            while (left < right &&
                   !char.IsLetterOrDigit(s[left]))
            {
                left++;
            }

            while (left < right &&
                   !char.IsLetterOrDigit(s[right]))
            {
                right--;
            }

            if (char.ToUpperInvariant(s[left]) !=
                char.ToUpperInvariant(s[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    // 4. Recursive solution
    static bool IsPalindromeRecursive(string? s)
    {
        if (s is null)
            return false;

        return Check(s, 0, s.Length - 1);
    }

    static bool Check(string s, int left, int right)
    {
        if (left >= right)
            return true;

        if (s[left] != s[right])
            return false;

        return Check(s, left + 1, right - 1);
    }

    static void Main()
    {
        Console.WriteLine("Palindrome Checker");
        Console.WriteLine("1. Exact string");
        Console.WriteLine("2. Ignore case");
        Console.WriteLine("3. Ignore spaces and punctuation");
        Console.WriteLine("4. Recursive check");
        Console.Write("Choose an option (1-4): ");

        string? choice = Console.ReadLine();

        bool result;

        switch (choice)
        {
            case "1":
                Console.Write("Enter a string: ");
                string? exact = Console.ReadLine();
                result = IsPalindrome(exact);
                break;

            case "2":
                Console.Write("Enter a string: ");
                string? insensitive = Console.ReadLine();
                result = IsPalindromeIgnoreCase(insensitive);
                break;

            case "3":
                Console.Write("Enter a string: ");
                string? text = Console.ReadLine();
                result = IsPalindromeAlphanumeric(text);
                break;

            case "4":
                Console.Write("Enter a string: ");
                string? recursive = Console.ReadLine();
                result = IsPalindromeRecursive(recursive);
                break;

            default:
                Console.WriteLine("Invalid option.");
                return;
        }

        Console.WriteLine(result);
    }
}
