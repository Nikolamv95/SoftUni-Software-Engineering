using FootballTeamGeneratorV2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGeneratorV2.Model
{
    public class Team
    {
        //Constants & Messages
        private string teamName;
        private readonly ICollection<Player> players;
        private int teamRating;

        //Constructors
        public Team(string name)
        {
            this.TeamName = name;
            this.players = new List<Player>();
        }

        //Properties
        public string TeamName
        {
            get
            {
                return this.teamName;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value) == true)
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExcMsg);
                }
                this.teamName = value;
            }
        }
        public IReadOnlyCollection<Player> Players
        {
            get
            {
                return (IReadOnlyCollection<Player>)this.players;
            }
        }
        public int TeamRating => this.players.Count > 0 ? (int)Math.Round(this.Players.Average(x => x.OverallSkill)) : 0;

        //Methods
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.PlayerName == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.PlayerDontExistExcMsg, playerName, this.TeamName));
            }
            else
            {
                this.players.Remove(playerToRemove);
            }
        }
        public string ShowTeamRating(string teamName)
        {
            if (this.TeamName == teamName)
            {
                return $"{this.TeamName} - {this.TeamRating}";
            }
            else
            {
                throw new ArgumentException(String.Format(GlobalConstants.TeamDontExistExcMsg, teamName));
            }
        }
        protected bool ValidateIsPlayerExist(Player player)
        {
            bool isExist = this.Players.Any(x => x.PlayerName == player.PlayerName);
            return isExist;
        }
    }
}
