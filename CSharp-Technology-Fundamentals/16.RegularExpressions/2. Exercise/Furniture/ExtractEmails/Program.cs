using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string patternEmails = @"([a-z]+[\.\-\\_]*[a-z]+[\.\-\\_]*[a-z]+@[a-z]+[\.\-\\_]*[a-z]+\.[a-z]+\.*[a-z]+)";
            Regex emailRegex = new Regex(patternEmails);
            MatchCollection matchedEmails = emailRegex.Matches(input);

            foreach (var item in matchedEmails)
            {
                Console.WriteLine(item);
            }
        }
    }
}
