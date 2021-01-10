using System;

namespace mathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = Calculation(number, power);
            Console.WriteLine(result);
        }

        private static double Calculation(double number, int power)
        {
            double result = Math.Pow(number,power);
            return result;
        }
    }
}
