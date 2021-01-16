using System;
using System.Collections.Generic;

namespace WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < inputs; i++)
            {
                string key = Console.ReadLine(); 
                string value = Console.ReadLine();

                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, new List<string> {value});
                }
                else
                {
                    dict[key].Add(value);
                }
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
