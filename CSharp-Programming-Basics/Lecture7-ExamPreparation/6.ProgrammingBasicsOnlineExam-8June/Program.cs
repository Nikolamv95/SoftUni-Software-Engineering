using System;

namespace Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double wantedProfit = double.Parse(Console.ReadLine());
            double clubIncome = 0;
            string coctailOrder = string.Empty;
            bool isAquired = false;

            while ((coctailOrder = Console.ReadLine()) != "Party!")
            {
                double numOfCoctails = double.Parse(Console.ReadLine());
                double priceOfCoctail = coctailOrder.Length;

                double currIncome = numOfCoctails * priceOfCoctail;

                if (currIncome % 2 != 0)
                {
                    currIncome = currIncome * 0.75;
                }

                clubIncome += currIncome;

                if (clubIncome >= wantedProfit)
                {
                    Console.WriteLine("Target acquired.");
                    Console.WriteLine($"Club income - {clubIncome:f2} leva.");
                    isAquired = true;
                    break;
                }
            }

            if (isAquired == false)
            {
                Console.WriteLine($"We need {wantedProfit - clubIncome:f2} leva more.");
                Console.WriteLine($"Club income - {clubIncome:f2} leva.");
            }
             
        }
    }
}
