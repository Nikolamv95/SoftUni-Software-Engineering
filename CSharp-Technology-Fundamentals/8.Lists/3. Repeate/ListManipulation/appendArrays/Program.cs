using System;
using System.Collections.Generic;
using System.Linq;

namespace appendArrays
{
    class Program
    {
        static void Main(string[] args)
        {


            List <string> numbers = Console.ReadLine()
                                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            numbers.Reverse();

            string result = String.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                string trimmed = numbers[i];
                char[] characters = trimmed.ToCharArray();

                for (int j = 0; j < characters.Length; j++)
                {
                    if (characters[j] != ' ')
                    {
                        result += characters[j] + " ";
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
