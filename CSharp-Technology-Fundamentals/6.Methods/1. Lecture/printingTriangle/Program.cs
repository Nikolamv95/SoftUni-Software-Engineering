using System;

namespace printingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j} ");

                }
                Console.WriteLine();
            }
            PrintLine(1, number);
        }

        static void PrintLine(int start, int end)
        {

            for (int i = end - 1; i >= 1; i--)
            {
                for (int j = start; j <= i; j++)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }
        }
    }
}
