using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPeople = Console.ReadLine()
                               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                               .ToArray();

            Dictionary<string, int> dicOfPeople = new Dictionary<string, int>();

            for (int i = 0; i < inputPeople.Length; i++)
            {
                string name = inputPeople[i];

                if (dicOfPeople.ContainsKey(name) == false)
                {
                    dicOfPeople.Add(name, 0);
                }
            }

            //създаваме патерн който матчваме символите от които се нуждаем
            string patternLetters = @"[A-Za-z]";
            string patternNumbers = @"[0-9]";

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                //използваме MatchCollection да вземем всички символи които отговарят на услвоието, като ги събираме в колекция
                MatchCollection matchesForText = Regex.Matches(input, patternLetters);
                MatchCollection matchesForDistance = Regex.Matches(input, patternNumbers);
                int sum = 0;

                //обхождаме колекцията и в sum събираме числата 
                foreach (Match digit in matchesForDistance)
                {
                    sum += int.Parse(digit.Value);
                }

                //обхождаме колекцията и конкатенираме буквите в name
                string name = string.Empty;
                foreach (Match letters in matchesForText)
                {
                    name += letters.Value;
                }

                if (dicOfPeople.ContainsKey(name) == true)
                {
                    dicOfPeople[name] += sum;
                }

                input = Console.ReadLine();
            }

            int z = 1;

            foreach (var item in dicOfPeople.OrderByDescending(v => v.Value))
            {
                if (z == 1)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                }
                else if (z == 2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                }
                else if (z == 3)
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                    break;
                }
                z++;
            }
        }
    }
}
