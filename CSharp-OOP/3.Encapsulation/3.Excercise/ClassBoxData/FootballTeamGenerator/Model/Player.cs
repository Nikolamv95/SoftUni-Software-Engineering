using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Model
{
    public class Player : Team
    {
        //Private messages
        public const string StatsExcMsg = "{0} should be between 0 and 100.";

        //Fields
        private string playerName;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;
        private double averagePlayerRating;

        //Constructors
        public Player(string playerName, double endurance, double sprint, double dribble, double passing, double shooting) 
        {
            this.PlayerName = playerName;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.AveragePlayerRating = CalculateAveragePlayerRating();
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
                if (string.IsNullOrEmpty(value) == true || string.IsNullOrWhiteSpace(value) == true)
                {
                    throw new ArgumentException(CommonExcMessages.InvalidNameExcMsg);
                }
                this.playerName = value;
            }
        }
        public double Endurance
        {
            get
            {
                return this.endurance;
            }
            protected set
            {
                ValidateStats(value, "Endurance");
                this.endurance = value;
            }
        }
        public double Sprint
        {
            get
            {
                return this.sprint;
            }
            protected set
            {
                ValidateStats(value, "Sprint");
                this.sprint = value;
            }
        }
        public double Dribble
        {
            get
            {
                return this.dribble;
            }
           protected set
            {
                ValidateStats(value, "Dribble");
                this.dribble = value;
            }
        }
        public double Passing
        {
            get
            {
                return this.passing;
            }
           protected set
            {
                ValidateStats(value, "Passing");
                this.passing = value;
            }
        }
        public double Shooting
        {
            get
            {
                return this.shooting;
            }
           protected set
            {
                ValidateStats(value, "Shooting");
                this.shooting = value;
            }
        }
        public double AveragePlayerRating
        { 
            get 
            {
                return this.averagePlayerRating;
            }
            protected set
            {
                this.averagePlayerRating = value;
            }
        }

        //Methods
        protected double CalculateAveragePlayerRating()
        {
            double playerRating = ((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5);
            playerRating = Math.Round(playerRating);
            return playerRating;
        }
        protected void ValidateStats(double value, string name)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(string.Format(StatsExcMsg, name));
            }
        }
    }
}
