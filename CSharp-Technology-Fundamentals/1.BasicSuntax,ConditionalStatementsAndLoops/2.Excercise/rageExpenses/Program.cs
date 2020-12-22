using System;

namespace rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGameCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int i = 1;
            double sumTrashes = 0;

            for (i = 1; i <= lostGameCount; i++)
            {
                if (i % 2 == 0)
                {
                    sumTrashes += headsetPrice;
                }
                if (i % 3 == 0)
                {
                    sumTrashes += mousePrice;
                }
                if (i % 6 == 0)
                {
                    sumTrashes += keyboardPrice;
                }
                if (i % 12 == 0)
                {
                    sumTrashes += displayPrice;
                }
            }
            Console.WriteLine($"Rage expenses: {sumTrashes:f2} lv.");
        }
    }
}
