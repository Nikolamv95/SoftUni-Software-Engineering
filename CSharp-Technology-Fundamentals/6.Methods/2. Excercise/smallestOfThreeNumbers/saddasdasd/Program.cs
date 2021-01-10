using System;

namespace saddasdasd
{
    class Program
    {
        static void Main(string[] args)
        {
            string phrase = Console.ReadLine();
            string[] words = phrase.Split(" ");

            Console.WriteLine(words[2]);
        }
    }
}
