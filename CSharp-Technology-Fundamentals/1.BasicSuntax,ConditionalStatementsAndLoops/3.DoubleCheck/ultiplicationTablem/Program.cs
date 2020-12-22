using System;

namespace ultiplicationTablem
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int result = 0;

            for (int i = number; i == number; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    result = i * j;

                    Console.WriteLine($"{i} X {j} = {result}");
                    
                }

            }
        }
    }
}
