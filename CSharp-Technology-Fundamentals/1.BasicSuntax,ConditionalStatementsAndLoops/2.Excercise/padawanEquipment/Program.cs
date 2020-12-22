using System;

namespace padawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int numberStudents = int.Parse(Console.ReadLine());
            double saberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double sabersTotalPrice = 0;
            double roberTotalPrice = 0;
            double beltTotalPrice = 0;
            int counter = 0;


            sabersTotalPrice = saberPrice * (Math.Ceiling(numberStudents + (numberStudents * 0.10)));
            roberTotalPrice = robePrice * numberStudents;

            for (int i = 1; i <= numberStudents; i++)
            {
                counter += 1;

                if (counter != 6)
                {
                   beltTotalPrice += beltPrice;
                }
                else
                {
                    counter = 0;
                }
            }

            double totalSum = sabersTotalPrice + roberTotalPrice + beltTotalPrice;

            if (totalSum <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                money = money - totalSum;
                Console.WriteLine($"Ivan Cho will need {Math.Abs(money):f2}lv more.");
            }
        }
    }
}
