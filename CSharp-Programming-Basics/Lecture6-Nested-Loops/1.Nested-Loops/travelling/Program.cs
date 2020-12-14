using System;

namespace travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            double savedMoney = 0;

            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());

                while (savedMoney < budget)
                {
                    double moneyToSave = double.Parse(Console.ReadLine());

                    savedMoney += moneyToSave;

                    if (savedMoney >= budget)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        savedMoney = 0;
                        break;
                    }
                }

                destination = Console.ReadLine();
            }
        }
    }
}
