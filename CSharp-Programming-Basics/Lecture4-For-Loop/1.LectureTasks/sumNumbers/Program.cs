using System;

namespace sumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCount = int.Parse(Console.ReadLine());
            int sum = 0;


            for (int i = 0; i < numCount; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                sum += numbers;
            }

            Console.WriteLine(sum);
        }
    }
}
