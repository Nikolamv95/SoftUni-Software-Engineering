using System;

namespace TournamentChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfDays = int.Parse(Console.ReadLine());
            string gameToPlay = string.Empty;
            int totalDayWins = 0;
            int totalDayLoses = 0;
            double totalMoneyRised = 0;

            for (int i = 0; i < numOfDays; i++)
            {
                int currDayWins = 0;
                int currDayLoses = 0;
                double currDayMoneyRised = 0;

                while ((gameToPlay = Console.ReadLine()) != "Finish")
                {
                    string gameResult = Console.ReadLine();

                    if (gameResult == "win")
                    {
                        currDayWins++;
                        currDayMoneyRised += 20;

                    }
                    else if (gameResult == "lose")
                    {
                        currDayLoses++;
                    }
                }

                if (currDayWins > currDayLoses)
                {
                    currDayMoneyRised = currDayMoneyRised + (currDayMoneyRised * 0.10);
                    totalMoneyRised += currDayMoneyRised;
                    totalDayWins++;
                }
                else
                {
                    totalMoneyRised += currDayMoneyRised;
                    totalDayLoses++;
                }
            }

            if (totalDayWins > totalDayLoses)
            {
                totalMoneyRised = totalMoneyRised + (totalMoneyRised * 0.20);
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoneyRised:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoneyRised:f2}");
            }
        }
    }
}
