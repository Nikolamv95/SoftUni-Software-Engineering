using System;

namespace pokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int powerN = int.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
            int factoryY = int.Parse(Console.ReadLine());
            int hit = 0;
            double devide50 = (double)powerN / 2;

            while (powerN >= distanceM)
            {
                powerN -= distanceM;

                if (powerN == devide50 && powerN != 0 && factoryY != 0)
                {
                    powerN /= factoryY;
                }

                hit += 1;
            }

            Console.WriteLine(powerN);
            Console.WriteLine(hit);
        }
    }
}
