using System;
using System.Linq;

namespace repeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                              .Split();

            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char[] wordLenght = input[i].ToCharArray();

                for (int j = 0; j < wordLenght.Length; j++)
                {
                    result += input[i];
                }
            }
            Console.WriteLine(result);
        }
    }
}
