using System;
using System.Diagnostics.Tracing;

namespace rageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double totalSum = 0;
            int counter = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                counter += 1;

                if (counter % 12 == 0)
                {
                    totalSum += displayPrice;
                }
                if (counter % 6 == 0)
                {
                    totalSum += keyboardPrice;
                }
                if (counter % 3 == 0)
                {
                    totalSum += mousePrice;
                }
                if (counter % 2 == 0)
                {
                    totalSum += headsetPrice;
                }
            }

            Console.WriteLine($"Rage expenses: {totalSum:f2} lv.");
        }
    }
}
