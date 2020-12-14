using System;

namespace cinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            double standardTicket = 0;
            double studentTicket = 0;
            double kidTicket = 0;
            double totalSoldTickets = 0;
            double ticketSoldDay = 0;
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
                    }
                    else if (typeTicket == "student")
                    {
                        studentTicket += 1;
                    }
                    else if (typeTicket == "kid")
                    {
                        kidTicket += 1;
                    }
                    else if (typeTicket == "End")
                    {
                        percentage = totalSoldTickets / freeSpace * 100;
                        Console.WriteLine($"{movieName} - {percentage:f2}% full.");
                        totalSoldTickets = 0;
                        break;
                    }

                    totalSoldTickets += 1;
                    ticketSoldDay += 1;

                    if (freeSpace <= totalSoldTickets)
                    {
                        percentage = totalSoldTickets / freeSpace * 100;
                        Console.WriteLine($"{movieName} - {percentage:f2}% full.");
                        totalSoldTickets = 0;
                        break;
                    }
                }
                movieName = Console.ReadLine();
            }

            double resultStudent = 0;
            double resultStandard = 0;
            double resultKids = 0;

            resultStudent = (studentTicket / ticketSoldDay) * 100;
            resultStandard = (standardTicket / ticketSoldDay) * 100;
            resultKids = (kidTicket / ticketSoldDay) * 100;

            Console.WriteLine($"Total tickets: {ticketSoldDay}");
            Console.WriteLine($"{resultStudent:f2}% student tickets.");
            Console.WriteLine($"{resultStandard:f2}% standard tickets.");
            Console.WriteLine($"{resultKids:f2}% kids tickets.");
        }
    }
}
