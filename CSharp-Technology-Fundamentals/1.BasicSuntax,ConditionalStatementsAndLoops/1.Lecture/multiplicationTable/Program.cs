using System;

namespace multiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var result = 0;

            for (int i = number; i == number; i++)
            {
                for (int times = 1; times <= 10; times++)
                {
                    result = number * times;

                    Console.WriteLine($"{number} X {times} = {result}");
                }
            }
        }
    }
}
