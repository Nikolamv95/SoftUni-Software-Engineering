using System;

namespace multiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            for (int i = 1; i <= 10; i++)
            {
                for (int m = 1; m <= 10; m++)
                {
                    result = i * m;
                    Console.WriteLine($"{i}*{m}={result}");
                }
            }
        }
    }
}
