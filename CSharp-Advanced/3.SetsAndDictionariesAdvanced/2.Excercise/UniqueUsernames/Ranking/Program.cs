using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dicContest = new Dictionary<string, string>();
            string contestInput = string.Empty;

            while ((contestInput = Console.ReadLine()) != "end of contests")
            {
                string[] data = contestInput.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!dicContest.ContainsKey(data[0]))
                {
                    dicContest.Add(data[0], data[1]);
                }
            }

            Dictionary<string, Dictionary<string, int>> dicUsers = new Dictionary<string, Dictionary<string, int>>();
            string usersInput = string.Empty;

            while ((usersInput = Console.ReadLine()) != "end of submissions")
            {
                string[] data = usersInput.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string contest = data[0];
                string password = data[1];
                string username = data[2];
                int points = int.Parse(data[3]);

                Dictionary<string, int> contestData = new Dictionary<string, int>();

                if (dicContest.ContainsKey(contest) && dicContest.ContainsValue(password))
                {
                    if (dicUsers.ContainsKey(username) == false)
                    {
                        //Добавяме играча
                        contestData.Add(contest, points);
                        dicUsers.Add(username, contestData);
                    }
                    else
                    {
                        //Ако играча същестува добавяме новия изпит към него
                        if (dicUsers[username].ContainsKey(contest) == false)
                        {
                            dicUsers[username].Add(contest, points);
                        }
                        else // Ако играча съществува и изпита също проверяваме оценката 
                        {
                            var tu = dicUsers[username].Single(x=>x.Key == contest);
                            int currPoints = tu.Value;

                            if (currPoints < points)
                            {
                                dicUsers[username][contest] = points;
                            }
                        }
                    }
                }
            }
            //Best Candidate
            int bestPoints = int.MinValue;
            string bestName = string.Empty;

            foreach ((string username, Dictionary<string, int> userData) in dicUsers)
            {
                int currPoints = userData.Values.Sum();
                if (currPoints > bestPoints)
                {
                    bestPoints = currPoints;
                    bestName = username;
                }
            }

            Console.WriteLine($"Best candidate is {bestName} with total {bestPoints} points.");
            //Pritn All the rest
            Console.WriteLine("Ranking:");
            foreach ((string username, Dictionary<string, int> userData) in dicUsers.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{username}");

                foreach ((string exam, int points) in userData.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {exam} -> {points}");
                }
            }
        }
    }
}
