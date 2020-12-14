using System;

namespace accountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string number1 = Console.ReadLine();
            
            double total = 0;

            while (number1 != "NoMoreMoney")
            {
                double number = Convert.ToDouble(number1);
                //double number = double.Parse(number1);

                if (number < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                total += number;
                Console.WriteLine($"Increase: {number:f2}");

                number1 = Console.ReadLine();
            }

            Console.WriteLine($"Total: {total:f2}");

        }
    }
}
