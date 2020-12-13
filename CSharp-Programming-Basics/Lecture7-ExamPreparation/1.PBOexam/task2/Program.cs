using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            double timeMinutes = double.Parse(Console.ReadLine());
            double timeSeconds = double.Parse(Console.ReadLine());
            double lengthPool = double.Parse(Console.ReadLine());
            double secondsToBeat100M = double.Parse(Console.ReadLine());

            timeMinutes *= 60;
            double fullTime = timeMinutes + timeSeconds;
            double slowTime = lengthPool / 120;
            double fullSlowTime = slowTime * 2.5;
            double timePlayer = (lengthPool / 100) * secondsToBeat100M - fullSlowTime;

            if (fullTime >= timePlayer)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {timePlayer:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {timePlayer - fullTime:f3} second slower.");
            }
        }
    }
}
