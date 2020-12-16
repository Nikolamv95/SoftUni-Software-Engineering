using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string cinemaType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double income = 0;
            double ticketPrice = 0;

            if (cinemaType == "Premiere")
            {
                ticketPrice = +12;
            }
            else if (cinemaType == "Normal")
            {
                ticketPrice = +7.50;
            }
            else if (cinemaType == "Discount")
            {
                ticketPrice = +5.00;
            }

            income = ticketPrice * rows * columns;

            Console.WriteLine($"{income:f2} leva");


        }
    }
}
