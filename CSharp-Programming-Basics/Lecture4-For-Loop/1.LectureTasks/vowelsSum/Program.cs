using System;
using System.Runtime.InteropServices.ComTypes;

namespace vowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int number = 0;

            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                switch (letter)
                {
                    case 'a':
                        number += 1;
                        break;
                    case 'e':
                        number += 2;
                        break;
                    case 'i':
                        number += 3;
                        break;
                    case 'o':
                        number += 4;
                        break;
                    case 'u':
                        number += 5;
                        break;
                }
            }
            Console.WriteLine(number);
        }
    }
}
