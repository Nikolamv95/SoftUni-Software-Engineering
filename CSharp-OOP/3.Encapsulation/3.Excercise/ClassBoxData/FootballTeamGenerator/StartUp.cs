using FootballTeamGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] teamNameInput = Console.ReadLine().Split(";").ToArray();
            Team team = new Team(teamNameInput[1]);
            var listOfPlayers = new List<Player>();

            string commandInput = string.Empty;
            while ((commandInput = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] commandData = commandInput.Split(";").ToArray();
                    string operation = commandData[0];

                    switch (operation)
                    {
                        case "Add":
                            AddPlayerToTeam(team, listOfPlayers, commandData);
                            break;
                        case "Remove":
                            RemovePlayerFromTeam(team, listOfPlayers, commandData);
                            break;
                        case "Rating":
                            string teamName = commandData[1];
                            Console.WriteLine(team.ShowTeamRating(teamName));
                            break;
                    }
                }
                catch (ArgumentException se)
                {
                    Console.WriteLine(se.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private static void RemovePlayerFromTeam(Team team, List<Player> listOfPlayers, string[] commandData)
        {
            string teamName = commandData[1];
            string playerName = commandData[2];
            //Очаквам проблем
            var playerToRemove = listOfPlayers.FirstOrDefault(x => x.PlayerName == playerName);

                team.RemovePlayer(playerToRemove, playerName);
                listOfPlayers.Remove(playerToRemove);
            
        }

        private static void AddPlayerToTeam(Team team, List<Player> listOfPlayers, string[] commandData)
        {
            string teamName = commandData[1];
            string playerName = commandData[2];
            double endurance = double.Parse(commandData[3]);
            double sprint = double.Parse(commandData[4]);
            double dribble = double.Parse(commandData[5]);
            double passing = double.Parse(commandData[6]);
            double shooting = double.Parse(commandData[7]);

            var currPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);

            listOfPlayers.Add(currPlayer);

            team.AddPlayer(currPlayer, teamName);
        }
    }
}
