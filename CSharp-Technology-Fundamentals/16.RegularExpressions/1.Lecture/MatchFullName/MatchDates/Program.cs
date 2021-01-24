using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string dates = Console.ReadLine();

            string patternDate = @"\b(?<day>[0-3][0-9])(?:(-)|(.)|(\/))(?<month>[A-Z][a-z]{2})(\1|\2|\3)(?<year>[0-9]{4})\b";
            var regexDate = new Regex(patternDate);
            var matches = regexDate.Matches(dates);

            foreach (Match date in matches)
            {
                var printDate = date.Groups["day"];
                var printMonth = date.Groups["month"];
                var printYear = date.Groups["year"];

                Console.WriteLine($"Day: {printDate}, Month: {printMonth}, Year: {printYear}");
            }

        }
    }
}
