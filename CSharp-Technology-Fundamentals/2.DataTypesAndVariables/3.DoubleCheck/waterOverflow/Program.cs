using System;

namespace waterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int capacity = 255;
            int sum = 0;

            for (int i = 0; i < lines; i++)
            {
                int quantities = int.Parse(Console.ReadLine());

                if (capacity >= quantities)
                {
                    capacity -= quantities;
                    sum += quantities;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(sum);
        }
    }
}
