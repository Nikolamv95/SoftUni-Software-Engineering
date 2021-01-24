using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternDate = @"(?<day>(?:[1-2]?[0-9])|(?:3[01]))-(?<month>[A-Z][a-z]{2})-(?<year>[0-9]{4})";
            var regexDate = new Regex(patternDate);
            
            string text = "Today is 25-Nov-2020 but probbably next year could be 25-Nov-2021";
            MatchCollection matches = regexDate.Matches(text);
            Console.WriteLine($"Found {matches.Count}");

            foreach (var match in matches)
            {
                Console.WriteLine($"this is the {match}");
            }

            //Replace text in a string with this pattern (find a date and repalce it)
            var newString = regexDate.Replace(text, "I`m the man");
            Console.WriteLine(newString);

            //Take the numbers in array without white space
            string patternWhiteSpace = @"\s+";
            var regexWhiteSpace = new Regex(patternWhiteSpace);
            string newText = "2    4 4 32 43               321 44 5";

            var arrayNumbers = Regex.Split(newText, patternWhiteSpace)
                               .Select(int.Parse)
                               .ToArray();
            ;
        }
    }
}
