using System;
using System.Linq;

namespace FootballResults
{
    class Program
    {
        static void Main(string[] args)
        {
            int won = 0;
            int draw = 0;
            int lose = 0;

            for (int i = 0; i < 3; i++)
            {
                string input = Console.ReadLine();

                char firstTeam = input[0];
                char secondTeam = input[2];

                if (firstTeam > secondTeam)
                {
                    won += 1;
                }
                else if (firstTeam == secondTeam)
                {
                    draw += 1;
                }
                else if (firstTeam < secondTeam)
                {
                    lose += 1;
                }
            }
            Console.WriteLine($"Team won {won} games.");
            Console.WriteLine($"Team lost {lose} games.");
            Console.WriteLine($"Drawn games: {draw}");
        }
    }
}
