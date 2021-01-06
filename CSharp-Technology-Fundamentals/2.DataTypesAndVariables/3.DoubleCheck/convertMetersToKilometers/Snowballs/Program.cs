using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = int.Parse(Console.ReadLine());
            BigInteger result = 0;
            BigInteger constant = int.MinValue;
            int snow = 0;
            int time = 0;
            int quality = 0;

            for (int i = 0; i < numberOfBalls; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

              
                    result = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                    if (result > constant)
                    {
                        constant = result;
                        snow = snowballSnow;
                        time = snowballTime;
                        quality = snowballQuality;
                    }
                
                
            }
            Console.WriteLine($"{snow} : {time} = {constant} ({quality})");
        }
    }
}
