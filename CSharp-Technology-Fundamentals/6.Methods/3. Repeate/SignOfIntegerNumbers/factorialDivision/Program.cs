using System;

namespace factorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int result = Caulculation(num1, num2);

            Console.WriteLine($"{result:f2}");
        }

        private static int Caulculation(int num1, int num2)
        {
            int result = 1;

            for (int i = num1; i > 0; i--)
            {
                result *= i;
            }

            result /= num2;

            return result;
        }
    }
}
