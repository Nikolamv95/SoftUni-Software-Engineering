using System;

namespace HighJump
{
    class Program
    {
        static void Main(string[] args)
        {
            string tournamentName;
            double wonGames = 0;
            double lostGames = 0;
            double gamesPlayed = 0;

            while ((tournamentName = Console.ReadLine()) != "End of tournaments")
            {
                int numOfGames = int.Parse(Console.ReadLine());

                for (int i = 1; i <= numOfGames; i++)
                {
                    gamesPlayed += 1;

                    int pointScoredByDesi = int.Parse(Console.ReadLine());
                    int pointScoredByOther = int.Parse(Console.ReadLine());

                    if (pointScoredByDesi > pointScoredByOther)
                    {
                        wonGames += 1;
                        Console.WriteLine($"Game {i} of tournament {tournamentName}: win with {pointScoredByDesi - pointScoredByOther} points.");
                    }
                    else
                    {
                        lostGames += 1;
                        Console.WriteLine($"Game {i} of tournament {tournamentName}: lost with {pointScoredByOther - pointScoredByDesi} points.");
                    }
                }
            }

            Console.WriteLine($"{((wonGames / gamesPlayed) * 100):f2}% matches win");
            Console.WriteLine($"{((lostGames / gamesPlayed) * 100):f2}% matches lost");
        }
    }
}
