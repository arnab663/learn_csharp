
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your text: ");
        string input = Console.ReadLine();

        Dictionary<string,int> wordFrequency = new Dictionary<string, int>();

        MatchCollection matches = Regex.Matches(
            input,
            @"[\p{L}\p{N}]+(?:['’][\p{L}\p{N}]+)*#?"
        );

        foreach(Match match in matches)
        {   
            string word = match.Value.ToLowerInvariant();
            if (wordFrequency.ContainsKey(word))
            {
                wordFrequency[word]++;
            }
            else wordFrequency[word] = 1;
        }

        foreach(var entry in wordFrequency.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{entry.Key} : {entry.Value}");
        }

        Console.WriteLine($"\nTotal number of unique words : {wordFrequency.Count}");

    }
}