using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator.Model
{
    public class Team
    {
        //Private messages
        public const string PlayerDontExistExcMsg = "Player {0} is not in {1} team.";
        public const string TeamDontExistExcMsg = "Team {0} does not exist.";

        //Fields
        private string playerName;
        private readonly ICollection<Player> players;
        private int teamRating = 0;

        //Constructors
        public Team()
        {

        }
        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        //Properties
        public string Name
        {
            get
            {
                return this.playerName;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value) == true || string.IsNullOrWhiteSpace(value) == true)
                {
                    throw new ArgumentException(CommonExcMessages.InvalidNameExcMsg);
                }
                this.playerName = value;
            }
        }
        public IReadOnlyCollection<Player> Players
        {
            get
            {
                return (IReadOnlyCollection<Player>)this.players;
            }
        }
        public int TeamRating
        {
            get
            {
                return this.teamRating;
            }
        }

        protected void CalcualteAvgTeamStats()
        {
            double teamRating = (int)this.players.Sum(x => x.AveragePlayerRating) / this.players.Count;
            this.teamRating = (int)teamRating;
        }
        public void AddPlayer(Player player, string teamName)
        {
            if (teamName == this.Name)
            {
                this.players.Add(player);
            }
            else
            {
                throw new ArgumentException(TeamDontExistExcMsg, teamName);
            }

            CalcualteAvgTeamStats();
        }
        public void RemovePlayer(Player player, string playerName)
        {
            if (ValidateIsPlayerExist(player) == false)
            {
                throw new InvalidOperationException(string.Format(PlayerDontExistExcMsg, playerName, this.Name));
            }

            this.players.Remove(player);
            CalcualteAvgTeamStats();
        }
        protected bool ValidateIsPlayerExist(Player player)
        {
            if (player == null)
            {
                return false;
            }
            bool isExist = this.Players.Any(x => x.PlayerName == player.PlayerName);
            return isExist;
        }
        public string ShowTeamRating(string teamName)
        {
            if (this.Name == teamName)
            {
                return $"{this.Name} - {this.TeamRating}";
            }
            else
            {
                throw new ArgumentException(String.Format(TeamDontExistExcMsg, teamName));
            }
        }
    }
}
