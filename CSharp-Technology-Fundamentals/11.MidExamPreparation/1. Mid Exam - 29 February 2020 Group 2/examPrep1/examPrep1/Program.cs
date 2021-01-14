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

            int hoursNeeded = 0;
            int counter = 0;

            while (answersToCheck > 0)
            {
                int maxAnswerPower = worker1 + worker2 + worker3;

                if (counter % 4 != 0)
                {
                    answersToCheck -= maxAnswerPower;
                    hoursNeeded++;
                }
            }
            Console.WriteLine(hoursNeeded);
        }
    }
}
