using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        string text = File.ReadAllText("Kobzar.txt");
        string[] words = Regex.Split(text, @"\W+");
        var wordCount = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (word.Length >= 3 && word.Length <= 20)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }
        }

        var sortedWordCount = wordCount.OrderByDescending(x => x.Value).Take(50);
        Console.WriteLine("+{0}+{1}+{2}+", new string('-', 4), new string('-', 32), new string('-', 17));
        Console.WriteLine("| {0,-2} | {1,-30} | {2,-10} |", "№", "слово", "встречается раз");
        Console.WriteLine("+{0}+{1}+{2}+", new string('-', 4), new string('-', 32), new string('-', 17));
        int i = 1;

        foreach (var pair in sortedWordCount)
        {
            Console.WriteLine("| {0,-2} | {1,-30} | {2,-15} |", i++, pair.Key, pair.Value);
        }
        Console.WriteLine("+{0}+{1}+{2}+", new string('-', 4), new string('-', 32), new string('-', 17));
    }
}