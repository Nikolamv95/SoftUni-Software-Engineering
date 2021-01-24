using System;
using System.Text.RegularExpressions;

namespace MatchFullNameTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            //\b служи за парсване на цял израз
            string patterFullName = @"\b([A-Z][a-z]+) ([A-Z][a-z]+)";
            var regexName = new Regex(patterFullName);
            var matches = regexName.Matches(text);

            Console.WriteLine(string.Join(' ', matches));
            
        }
    }
}
