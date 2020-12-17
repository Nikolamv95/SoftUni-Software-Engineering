using System;

namespace _14._VacationBookList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int pages = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int daysOfReading = int.Parse(Console.ReadLine());

            //Calculations
            double maxTimeForReading = pages / pagesPerHour;
            double hoursForReading = maxTimeForReading / daysOfReading;

            //Output
            Console.WriteLine($"{hoursForReading:f2}");

        }
    }
}
