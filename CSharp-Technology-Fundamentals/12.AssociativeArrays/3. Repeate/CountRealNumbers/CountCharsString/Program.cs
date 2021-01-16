using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .ToArray();
            Dictionary<char, int> dic = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char[] charecters = input[i].ToCharArray();

                for (int j = 0; j < charecters.Length; j++)
                {
                    if (dic.ContainsKey(charecters[j]) == false)
                    {
                        dic.Add(charecters[j], 1);
                    }
                    else
                    {
                        dic[charecters[j]]++;
                    }
                }
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
