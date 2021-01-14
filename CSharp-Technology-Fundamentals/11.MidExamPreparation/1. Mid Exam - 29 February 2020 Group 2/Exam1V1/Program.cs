using System;

namespace examPrep1
{
    class Program
    {
        static void Main(string[] args)
        {
            int worker1 = int.Parse(Console.ReadLine());
            int worker2 = int.Parse(Console.ReadLine());
            int worker3 = int.Parse(Console.ReadLine());
            int answersToCheck = int.Parse(Console.ReadLine());

            int maxAnswerPower = worker1 + worker2 + worker3;

            int hoursNeeded = 0;
            int hoursPast = 1;


            while (answersToCheck > 0)
            {
                
                if (hoursPast % 4 != 0)
                {
                    answersToCheck -= maxAnswerPower;
                    hoursNeeded++;
                }
                else
                {
                    hoursNeeded++;
                }

                hoursPast++;
            }
            Console.WriteLine($"Time needed: {hoursNeeded}h.");
        }
    }
}
