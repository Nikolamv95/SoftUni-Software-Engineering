using System;

namespace printPartOfAsciiTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputStart = int.Parse(Console.ReadLine());
            int InputEnd = int.Parse(Console.ReadLine());

            for (int i = inputStart; i <= InputEnd; i++)
            {
                char c = Convert.ToChar(i);
                Console.Write($"{c} ");
            }
        }
    }
}
