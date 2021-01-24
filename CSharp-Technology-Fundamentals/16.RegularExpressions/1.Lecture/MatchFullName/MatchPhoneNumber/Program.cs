using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string numberPattern = @"(\+[3][5][9])(( )|(-))([2])(\2|\3)(\d{3})(\2|\3)(\d{4})\b";
            var matchedPhones = Regex.Matches(input, numberPattern);
            var phoneArr = matchedPhones
                           .Cast<Match>()
                           .Select(a => a.Value.Trim())
                           .ToArray();

            Console.WriteLine(string.Join(", ", phoneArr));

        }
    }
}
