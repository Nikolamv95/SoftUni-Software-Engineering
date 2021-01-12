using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamworkProjects
{
    class Team
    {

        public string TeamName { get; set; }
        public string CreatorName { get; set; }
        public List<string> Members { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            int teamCount = int.Parse(Console.ReadLine());
            List<Team> listOfTeams = new List<Team>();

            for (int i = 0; i < teamCount; i++)
            {
                string[] input = Console.ReadLine()
                                .Split("-").ToArray();

                string creatorName = input[0];
                string teamName = input[1];

                Team team = new Team();

                if (!listOfTeams.Select(x => x.TeamName).Contains(team.TeamName))
                {
                    if (!listOfTeams.Select(x => x.CreatorName).Contains(team.CreatorName))
                    {
                        listOfTeams.Add(team);
                        Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                    }
                }
                else
                {
                    Console.WriteLine($"{teamName} cannot create another team!");
                }
            }



            string teamMembers = Console.ReadLine();

            while (teamMembers != "end of assignment")
            {
                string[] input = teamMembers.Split(new char[] { '-', '>' }).ToArray();

                string newUser = input[0];
                string teamName = input[2];

                bool isTeamExist = listOfTeams
                                            .Select(x => x.TeamName)
                                            .Contains(teamName);

                bool isCreatorExist = listOfTeams
                                            .Select(x => x.CreatorName)
                                            .Contains(newUser);

                bool isMemberxist = listOfTeams
                                            .Select(x => x.Members)
                                            .Any(x => x.Contains(newUser));
                if (!isTeamExist)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (isMemberxist || isCreatorExist)
                {
                    Console.WriteLine($"Member {newUser} cannot join team {teamName}!");
                }
                else
                {
                    int indexOfTeam = listOfTeams.FindIndex(x => x.TeamName == teamName);

                    listOfTeams[indexOfTeam].Members.Add(newUser);
                }

                teamMembers = Console.ReadLine();
            }

            Team[] teamsToDisband = listOfTeams.OrderBy(x => x.TeamName)
                                               .Where(x => x.Members.Count == 0)
                                               .ToArray();

            Team[] eligibleTeams = listOfTeams.OrderByDescending(x => x.Members.Count)
                                              .ThenBy(x => x.TeamName)
                                              .Where(x => x.Members.Count > 0)
                                              .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (Team team in eligibleTeams)
            {
                sb.AppendLine($"{team.TeamName}");
                sb.AppendLine($"- {team.CreatorName}");

                foreach (var members in team.Members.OrderBy(x => x))
                {
                    sb.AppendLine($"-- {members}…");
                }

            }

            sb.AppendLine($"Teams to disband:");
            foreach (Team teams in teamsToDisband)
            {
                sb.AppendLine($"{teams.TeamName}");
            }
            Console.WriteLine(sb);
        }
    }
}
