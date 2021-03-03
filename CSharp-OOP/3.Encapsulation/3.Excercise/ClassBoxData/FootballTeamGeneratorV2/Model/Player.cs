using FootballTeamGeneratorV2.Common;
using System;

namespace FootballTeamGeneratorV2.Model
{
    public class Player
    {
        //Fields
        private string playerName;
        private Stats stats;

        //Constructors
        public Player(string name, Stats stats)
        {
            this.playerName = name;
            this.Stats = stats;
        }

        //Properties
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value) == true)
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExcMsg);
                }
                this.playerName = value;
            }
        }
        public Stats Stats 
        {
            get 
            {
                return this.stats;
            }
            private set 
            {
                this.stats = value;
            } 
        }
        public double OverallSkill => this.Stats.AverageStats;
    }
}
