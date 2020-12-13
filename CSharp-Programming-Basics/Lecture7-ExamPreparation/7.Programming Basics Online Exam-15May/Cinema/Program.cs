
using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfSeats = int.Parse(Console.ReadLine());
            int pricePerTicket = 5;
            string input = string.Empty;
            int totalAmount = 0;
            int amountOfSeats = 0;
            bool isFull = false;

            while ((input = Console.ReadLine()) != "Movie time!")
            {
                int seatsToTake = int.Parse(input);
                amountOfSeats += seatsToTake;

                if (amountOfSeats <= numOfSeats)
                {
                    if (seatsToTake % 3 == 0)
                    {
                        totalAmount += (seatsToTake * pricePerTicket) - 5;
                    }
                    else
                    {
                        totalAmount += seatsToTake * pricePerTicket;
                    }
                }
                else
                {
                    Console.WriteLine("The cinema is full.");
                    isFull = true;
                    break;
                }
            }

            if (isFull == false)
            {
                Console.WriteLine($"There are {numOfSeats - amountOfSeats} seats left in the cinema.");
            }
            Console.WriteLine($"Cinema income - {totalAmount} lv.");
        }
    }
}
