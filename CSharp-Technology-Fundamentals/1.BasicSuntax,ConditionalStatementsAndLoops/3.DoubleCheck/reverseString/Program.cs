using System;

namespace reverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string reversedWord = string.Empty;

            for (int i = name.Length - 1; i >= 0; i--)
            {
                char letter = name[i];
                reversedWord += letter;
            }
            Console.WriteLine(reversedWord);
        }
    }
}
