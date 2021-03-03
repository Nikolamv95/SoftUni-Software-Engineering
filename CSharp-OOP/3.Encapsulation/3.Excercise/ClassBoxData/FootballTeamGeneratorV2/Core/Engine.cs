using FootballTeamGeneratorV2.Common;
using FootballTeamGeneratorV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGeneratorV2.Core
{
    public class Engine
    {
        private readonly ICollection<Team> teams;
        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(";").ToArray();
                string cmdType = cmdArgs[0];

                try
                {
                    List<string> cmdParams = cmdArgs.Skip(1).ToList();

                    switch (cmdType)
                    {
                        case "Team":
                            this.CreateTeam(cmdParams);
                            break;
                        case "Add":
                            this.AddPlayerToTeam(cmdParams);
                            break;
                        case "Remove":
                            this.RemovePlayerFromTeam(cmdParams);
                            break;
                        case "Rating":
                            this.RateTeam(cmdParams);
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private void CreateTeam(IList<string> cmdArgs)
        {
            string teamName = cmdArgs[0];
            Team team = new Team(teamName);
            this.teams.Add(team);
        }
        private void AddPlayerToTeam(IList<string> cmdArgs)
        {
            string teamName = cmdArgs[0];
            string playerName = cmdArgs[1];

            this.ValidateTeamExist(teamName);

            Stats stats = this.BuildStats(cmdArgs.Skip(2).ToArray());

            Player player = new Player(playerName, stats);
            
            Team team = this.teams.First(t => t.TeamName == teamName);
            team.AddPlayer(player);
        }
        private Stats BuildStats(string[] stats)
        {
            int endurance = int.Parse(stats[0]);
            int sprint = int.Parse(stats[1]);
            int dribble = int.Parse(stats[2]);
            int passing = int.Parse(stats[3]);
            int shooting = int.Parse(stats[4]);

            Stats currStats = new Stats(endurance, sprint, dribble, passing, shooting);
            return currStats;
        }
        private void ValidateTeamExist(string teamName)
        {
            if (!this.teams.Any(t => t.TeamName == teamName))
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.TeamDontExistExcMsg, teamName));
            }
        }
        private void RemovePlayerFromTeam(IList<string> cmdArgs)
        {
            string teamName = cmdArgs[0];
            string playerName = cmdArgs[1];
            this.ValidateTeamExist(teamName);

            Team team = this.teams.First(t => t.TeamName == teamName);
            team.RemovePlayer(playerName);
        }
        private void RateTeam(IList<string> cmdArgs)
        {
            string teamName = cmdArgs[0];
            this.ValidateTeamExist(teamName);

            Team team = this.teams.First(t => t.TeamName == teamName);
            Console.WriteLine(team.ShowTeamRating(teamName));
        }

        
    }
}
