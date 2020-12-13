using System;

namespace vetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDays = int.Parse(Console.ReadLine());
            int numberHours = int.Parse(Console.ReadLine());

            // Четен ден и нечетен час, паркингът таксува 2.50 лева.
            // Нечетен ден и четен час таксата е 1.25 лева.
            // Четен ден и четен час таксата е 1.00 лева.
            // Нечетен ден и нечетен час таксата е 1.00 лева.
            // Таксуването става на всеки изминал час от деня.
            // Всеки един от изходите трябва да бъде закръглен до втория след десетичната запетая.
            //

            double parkingTax = 0;
            double totalDayTax = 0;
            for (int i = 1; i <= numberDays; i++)
            {
                for (int n = 1; n <= numberHours; n++)
                {
                    if (i % 2 == 0 && n % 2 != 0)
                    {
                        parkingTax += 2.50;
                    }
                    else if (i % 2 != 0 && n % 2 == 0)
                    {
                        parkingTax += 1.25;
                    }
                    else
                    {
                        parkingTax += 1.00;
                    }
                }
                Console.WriteLine($"Day: {i} - {parkingTax:f2} leva");
                totalDayTax += parkingTax;
                parkingTax = 0;
            }
                Console.WriteLine($"Total: {totalDayTax:f2} leva");
        }
    }
}
