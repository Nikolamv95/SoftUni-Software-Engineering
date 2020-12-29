using System;
using System.Numerics;

namespace snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowballsMade = int.Parse(Console.ReadLine());
            BigInteger snowballResult = 0;
            BigInteger winner = 0;
            int snow = 0;
            int time = 0;
            int quality = 0;

            for (int i = 1; i <= snowballsMade; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                snowballResult = (snowballSnow / snowballTime);
                snowballResult = BigInteger.Pow(snowballResult, snowballQuality);

                if (snowballResult > winner)
                {
                    winner = snowballResult;
                    snow = snowballSnow;
                    time = snowballTime;
                    quality = snowballQuality;
                }
            }
            Console.WriteLine($"{snow} : {time} = {winner} ({quality})");
        }
    }
}
