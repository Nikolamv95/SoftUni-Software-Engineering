using System;

namespace orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            Calculation(order, quantity);
        }

        static void Calculation (string order, double quantity)
        {
            double result = 0;
            switch (order)
            {
                case "coffee":
                    result = quantity * 1.50;
                    break;
                case "water":
                    result = quantity * 1.00;
                    break;
                case "coke":
                    result = quantity * 1.40;
                    break;
                case "snacks":
                    result = quantity * 2.00;
                    break;
            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
