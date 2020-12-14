using System;

namespace cinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            int standardTicket = 0;
            int studentTicket = 0;
            int kidTicket = 0;
            int totalSoldTickets = 0;
            int totalSoldTicketsPerDay = 0;
            double percentage = 0;

            while (movieName != "Finish")
            {
                double freeSpace = double.Parse(Console.ReadLine());

                while (true)
                {
                    string typeTicket = Console.ReadLine();

                    if (typeTicket == "standard")
                    {
                        standardTicket += 1;
                        totalSoldTickets += 1;
                        totalSoldTicketsPerDay += 1;
                    }
                    else if (typeTicket == "student")
                    {
                        studentTicket += 1;
                        totalSoldTickets += 1;
                        totalSoldTicketsPerDay += 1;
                    }
                    else if (typeTicket == "kid")
                    {
                        kidTicket += 1;
                        totalSoldTickets += 1;
                        totalSoldTicketsPerDay += 1;
                    }

                    if (typeTicket == "End" || totalSoldTickets == freeSpace)
                    {
                        percentage = totalSoldTickets / freeSpace * 100;
                        Console.WriteLine($"{movieName} - {percentage:f2}% full.");
                        totalSoldTickets = 0;
                        break;
                    }

                    totalSoldTickets += 1;
                }
                movieName = Console.ReadLine();
            }
        }
    }
}
