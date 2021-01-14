using System;

namespace taks1
{
    class Program
    {
        static void Main(string[] args)
        {
            int employee1 = int.Parse(Console.ReadLine());
            int employee2 = int.Parse(Console.ReadLine());
            int employee3 = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int maxPowerHourly = employee1 + employee2 + employee3;
            int hoursNeeded = 0;
            int restHour = 1;

            while (studentsCount > 0)
            {
                if(restHour % 4 == 0)
                {
                    hoursNeeded++;
                }
                else
                {
                    studentsCount -= maxPowerHourly;
                    hoursNeeded++;
                }
                restHour++;
            }

            Console.WriteLine($"Time needed: {hoursNeeded}h.");
        }
    }
}
