using System;

namespace pokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int nPokePower = int.Parse(Console.ReadLine());
            int mDistance = int.Parse(Console.ReadLine());
            int yExhaustionFactor = int.Parse(Console.ReadLine());
            int targetReached = 0;
            double nPokerPower50Percent = nPokePower * 0.50;

            while (nPokePower >= mDistance)
            {
                nPokePower -= mDistance;
                targetReached += 1;

                if (nPokerPower50Percent == nPokePower && yExhaustionFactor != 0)
                {
                    nPokePower /= yExhaustionFactor;
                }
            }

            Console.WriteLine(nPokePower);
            Console.WriteLine(targetReached);

        }
    }
}
