using System;

namespace foodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
                int chickenMenue = int.Parse(Console.ReadLine());
                int fishMenue = int.Parse(Console.ReadLine());
                int vegetarianMenue = int.Parse(Console.ReadLine());

                double chickenQ = 10.35;
                double fishQ = 12.40;
                double vegetarianQ = 8.15;
                double delivery = 2.50;
                double dessert = 0;
                double totalPrice = 0;

                chickenQ = chickenQ * chickenMenue;
                fishQ = fishQ * fishMenue;
                vegetarianQ = vegetarianQ * vegetarianMenue;

                totalPrice = chickenQ + fishQ + vegetarianQ;
                dessert = totalPrice * 0.2;
                totalPrice = totalPrice + dessert + delivery;


            Console.WriteLine($"Total: {totalPrice:f2}");

        }
    }
}
