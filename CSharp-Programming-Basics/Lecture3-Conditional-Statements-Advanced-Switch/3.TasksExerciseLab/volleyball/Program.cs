using System;

namespace volleyball
{
    class Program
    {
        static void Main(string[] args)
        {

            string typeOfYear = Console.ReadLine();
            int daysVacation = int.Parse(Console.ReadLine());
            int weekendsTravel = int.Parse(Console.ReadLine());

            double allWeekends = 48;
            double saturdayGamesInSofia = 0;
            double gamesInSofiaVacationDays = 0;
            double totalGames = 0;
            double additionalGames = 0.15;

            double weekendsInSofia = allWeekends - weekendsTravel;
            saturdayGamesInSofia = weekendsInSofia - (weekendsInSofia / 4);
            gamesInSofiaVacationDays = daysVacation * 0.6666666666666667;
            totalGames = saturdayGamesInSofia + gamesInSofiaVacationDays + weekendsTravel;

            if (typeOfYear == "leap")
            {
                totalGames = (totalGames * additionalGames) + totalGames;
                Console.WriteLine($"{Math.Floor(totalGames)}");
            }
            else
            {
                Console.WriteLine($"{Math.Floor(totalGames)}");
            }
        }
    }
}
