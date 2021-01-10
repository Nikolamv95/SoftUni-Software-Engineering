using System;

namespace factorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());

            double firstNum = Calculation(number1);
            double secondNum = Calculation2(number2);

            double result = firstNum / secondNum;

            Console.WriteLine($"{result:f2}");
        }

        static double Calculation(double number1)
        {
            double result = 1;
            for (double i = number1; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }
        static double Calculation2(double number2)
        {
            double result = 1;
            for (double i = number2; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }
    }
}
