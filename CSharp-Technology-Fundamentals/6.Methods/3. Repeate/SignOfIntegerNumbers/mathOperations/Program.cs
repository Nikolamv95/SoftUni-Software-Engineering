using System;

namespace mathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());

            int result = Calculation(num1, operation, num2);
            Console.WriteLine(result);
        }

        private static int Calculation(int num1, string operation, int num2)
        {
            int result = 0;

            switch (operation)
            {
                case "*":
                    result = GetMult(num1, num2);
                    break;
                case "/":
                    result = GetDiv(num1, num2);
                    break;
                case "+":
                    result = GetSum(num1, num2);
                    break;
                case "-":
                    result = GetMinus(num1, num2);
                    break;
            }
            return result;
        }

        private static int GetMult(int num1, int num2)
        {
            int result = num1 * num2;
            return result;
        }

        private static int GetSum(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }

        private static int GetDiv(int num1, int num2)
        {
            int result = num1 / num2;
            return result;
        }

        private static int GetMinus(int num1, int num2)
        {
            int result = num1 - num2;
            return result;
        }
    }
}
