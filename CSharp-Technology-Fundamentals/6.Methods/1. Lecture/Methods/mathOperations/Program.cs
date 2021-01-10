using System;

namespace mathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            double number2 = double.Parse(Console.ReadLine());
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = CalculationAdd (number1, number2);
                    break;
                case "-":
                    result = CalculationMinus (number1, number2);
                    break;
                case "*":
                    result = CalculationMultip(number1, number2);
                    break;
                case "/":
                    result = CalculationDevide(number1, number2);
                    break;
            }

            Console.WriteLine(result);
        }

        static double CalculationAdd(double number1, double number2)
        {
            double result = number1 + number2;
            return result;
        }

        static double CalculationMinus(double number1, double number2)
        {
            double result = number1 - number2;
            return result;
        }

        static double CalculationMultip(double number1, double number2)
        {
            double result = number1 * number2;
            return result;
        }

        static double CalculationDevide(double number1, double number2)
        {
            double result = number1 / number2;
            return result;
        }
    }
}
