using System;

namespace Time_15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 15;

            if (minutes >= 60)
            {
                minutes = minutes - 60;
            }
            else if (hour >= 24)
            {
                hour = 0;          
            }
            Console.WriteLine($"{hour}:{minutes:d2}");
        }
    }
}
