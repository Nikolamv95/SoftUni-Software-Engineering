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

            //създаваме патерн който премахва излишните символи
            string patternLetters = @"[\W\d]";
            string patternNumbers = @"[\WA-Za-z]";

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                //премахваме излишните символи с функцията Regex.Replace
                string name = Regex.Replace(input, patternLetters, "");
                string numbers = Regex.Replace(input, patternNumbers, "");
                int sum = 0;

                //Взимаме сумата на числата които се съдържат в string numbers
                foreach (var digit in numbers)
                {
                    int currDigit = int.Parse(digit.ToString());
                    sum += currDigit;
                }

                if (dicOfPeople.ContainsKey(name) == true)
                {
                    dicOfPeople[name] += sum;
                }

                input = Console.ReadLine();
            }
            
            int z = 1;

            foreach (var item in dicOfPeople.OrderByDescending(v=> v.Value))
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
