using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string numberRegex = @"(\d+)";
            string emojyRegex = @"(([\*]{2})|([\:]{2}))([A-Z][a-z]{2,})\1";

            MatchCollection matchedNumbers = Regex.Matches(input, numberRegex);
            MatchCollection matchedEmojy = Regex.Matches(input, emojyRegex);

            int threshold = 1;

            foreach (Match item in matchedNumbers)
            {
                int currDigit = 0;

                if (item.Length > 1)
                {
                    char[] characters = item.Value.ToCharArray();

                    for (int i = 0; i < characters.Length; i++)
                    {
                        string currNum = characters[i].ToString();
                        currDigit = int.Parse(currNum);
                        threshold *= currDigit;
                    }
                }
                else
                {
                    currDigit = int.Parse(item.Value);
                    threshold *= currDigit;
                }
            }

            Console.WriteLine($"Cool threshold: {threshold}");

            List<string> listOfEmojies = new List<string>();

            foreach (Match item in matchedEmojy)
            {
                char[] characters = item.Value.ToCharArray();
                int emojyResult = 0;

                for (int i = 0; i < characters.Length; i++)
                {
                    if (characters[i] != '*' && characters[i] != ':')
                    {
                        emojyResult += characters[i];
                    }
                }

                if (emojyResult >= threshold)
                {
                    listOfEmojies.Add(item.Value);
                }
            }

            Console.WriteLine($"{matchedEmojy.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join(Environment.NewLine, listOfEmojies));
        }
    }
}
