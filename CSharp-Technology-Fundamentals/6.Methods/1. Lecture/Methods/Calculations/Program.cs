using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    Add(number1, number2);
                    break;
                case "multiply":
                    Multiply(number1, number2);
                    break;
                case "subtract":
                    Subtract(number1, number2);
                    break;
                case "divide":
                    Devide(number1, number2);
                    break;

            }
        }


        private static void Add(double numberTo1, double numberTo2)
        {
            double result = numberTo1 + numberTo2;
            Console.WriteLine(result);
        }
        private static void Multiply(double numberTo1, double numberTo2)
        {
            double result = numberTo1 * numberTo2;
            Console.WriteLine(result);
        }
        private static void Subtract(double numberTo1, double numberTo2)
        {
            double result = numberTo1 % numberTo2;
            Console.WriteLine(result);
        }
        private static void Devide(double numberTo1, double numberTo2)
        {
            double result = numberTo1 / numberTo2;
            Console.WriteLine(result);
        }
    }
}
