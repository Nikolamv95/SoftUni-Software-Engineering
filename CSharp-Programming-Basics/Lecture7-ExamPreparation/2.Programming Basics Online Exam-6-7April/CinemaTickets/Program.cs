using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieInput;
            int totalSaledTickets = 0;
            int totalStudentTickets = 0;
            int totalStandartTickets = 0;
            int totalKidTickets = 0;
            

            while ((movieInput = Console.ReadLine()) != "Finish")
            {
                int maxTickets = int.Parse(Console.ReadLine());
                bool isNotFull = false;
                int currMovieSaledTickets = 0;

                for (int i = 1; i <= maxTickets; i++)
                {
                    string typeOfTicket = Console.ReadLine();

                    switch (typeOfTicket)
                    {
                        case "student":
                            totalSaledTickets += 1;
                            totalStudentTickets += 1;
                            currMovieSaledTickets += 1;
                            break;
                        case "standard":
                            totalSaledTickets += 1;
                            totalStandartTickets += 1;
                            currMovieSaledTickets += 1;
                            break;
                        case "kid":
                            totalSaledTickets += 1;
                            totalKidTickets += 1;
                            currMovieSaledTickets += 1;
                            break;
                        case "End":
                            isNotFull = true;
                            break;
                    }

                    if (isNotFull == true)
                    {
                        isNotFull = false;
                        break;
                    }
                }

            }

            Console.WriteLine($"Total tickets: {totalSaledTickets}");
            
        }
    }
}
