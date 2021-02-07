using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string textName = "text.txt";
            string wordsName = "words.txt";
            string result1 = "actualResult.txt";
            string result2 = "expectedResul.txt";

            var textLines = File.ReadAllLines(textName);
            var wordLines = File.ReadAllLines(wordsName);

            string[] textArray = new string[textLines.Length];
            string[] wordArray = new string[wordLines.Length];

            for (int i = 0; i < textLines.Length; i++)
            {
                textArray[i] = textLines[i];
            }
            for (int i = 0; i < wordLines.Length; i++)
            {
                wordArray[i] = wordLines[i];
            }

            String pattern = @"[a-zA-Z']+";
            Regex regex = new Regex(pattern);
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            for (int i = 0; i < textArray.Length; i++)
            {
                foreach (Match match in regex.Matches(textArray[i]))
                {
                    for (int z = 0; z < wordArray.Length; z++)
                    {
                        if (match.Value.ToLower() == wordArray[z])
                        {
                            if (dictionary.ContainsKey(match.Value.ToLower()) == false)
                            {
                                dictionary.Add(match.Value.ToLower(), 1);
                            }
                            else
                            {
                                dictionary[match.Value.ToLower()]++;
                            }
                        }
                        
                    }
                }
            }

            string[] result = new string[dictionary.Count];
            int counter = 0;
            foreach (var item in dictionary)
            {
                result[counter++] = $"{item.Key} - {item.Value}";
            }
            File.WriteAllLines(result1, result);

            string[] resultFinal = new string[dictionary.Count];
            int counter2 = 0;
            foreach (var item in dictionary.OrderByDescending(x=>x.Value))
            {
                resultFinal[counter2++] = $"{item.Key} - {item.Value}";
            }
            File.WriteAllLines(result2, resultFinal);
        }
    }
}
