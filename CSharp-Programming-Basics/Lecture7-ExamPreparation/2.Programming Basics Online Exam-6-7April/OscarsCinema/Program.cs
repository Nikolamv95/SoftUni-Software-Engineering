using System;

namespace OscarsCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            string typeOfRoom = Console.ReadLine();
            double numTickets = double.Parse(Console.ReadLine());

            double fullPrice = 0;

            switch (movieName)
            {
                case "A Star Is Born":
                    if (typeOfRoom == "normal")
                    {
                        fullPrice = numTickets * 7.50;
                    }
                    else if (typeOfRoom == "luxury")
                    {
                        fullPrice = numTickets * 10.50;
                    }
                    else if (typeOfRoom == "ultra luxury")
                    {
                        fullPrice = numTickets * 13.50;
                    }
                    break;
                case "Bohemian Rhapsody":
                    if (typeOfRoom == "normal")
                    {
                        fullPrice = numTickets * 7.35;
                    }
                    else if (typeOfRoom == "luxury")
                    {
                        fullPrice = numTickets * 9.45;
                    }
                    else if (typeOfRoom == "ultra luxury")
                    {
                        fullPrice = numTickets * 12.75;
                    }
                    break;
                case "Green Book":
                    if (typeOfRoom == "normal")
                    {
                        fullPrice = numTickets * 8.15;
                    }
                    else if (typeOfRoom == "luxury")
                    {
                        fullPrice = numTickets * 10.25;
                    }
                    else if (typeOfRoom == "ultra luxury")
                    {
                        fullPrice = numTickets * 13.25;
                    }
                    break;
                case "The Favourite":
                    if (typeOfRoom == "normal")
                    {
                        fullPrice = numTickets * 8.75;
                    }
                    else if (typeOfRoom == "luxury")
                    {
                        fullPrice = numTickets * 11.55;
                    }
                    else if (typeOfRoom == "ultra luxury")
                    {
                        fullPrice = numTickets * 13.95;
                    }
                    break;
            }
            Console.WriteLine($"{movieName} -> {fullPrice:f2} lv.");
        }
    }
}
