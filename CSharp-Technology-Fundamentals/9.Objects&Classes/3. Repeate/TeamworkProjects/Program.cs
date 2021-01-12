using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            List<Team> listOfTeams = new List<Team>();
            List<string> listOfMembers = new List<string>();


            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine()
                                .Split('-', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

                string creatorName = input[0];
                string teamName = input[1];

                Team team = new Team();

                team.TeamName = teamName;
                team.Creator = creatorName;
                team.Members = listOfMembers;

                if (!listOfTeams.Select(x => x.TeamName).Contains(teamName))
                {
                    if (!listOfTeams.Select(x => x.Creator).Contains(creatorName))
                    {
                        Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                        listOfTeams.Add(team);
                    }
                    else
                    {
                        Console.WriteLine($"{creatorName} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
            }

            string addMember = string.Empty;

            while ((addMember = Console.ReadLine()) != "end of assignment")
            {
                var data = addMember
                                   .Split("->", StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

                string memberJoin = data[0];
                string teamToJoin = data[1];


                bool isTeamExist = listOfTeams
                                            .Select(x => x.TeamName)
                                            .Contains(teamToJoin);

                bool isCreatorExist = listOfTeams
                                                .Select(m => m.Creator)
                                                .Contains(memberJoin);

                bool isMemberxist = listOfTeams.Select(m => m.Members).Any(n => n.Contains(memberJoin));

                if (isTeamExist == false)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if (isMemberxist || isCreatorExist)
                {
                    Console.WriteLine($"Member {memberJoin} cannot join team {teamToJoin}!");
                }
                else
                {
                    int indexTeam = listOfTeams.FindIndex(x => x.TeamName == teamToJoin);
                    listOfTeams[indexTeam].Members.Add(memberJoin);
                }
            }


        }
    }
}
