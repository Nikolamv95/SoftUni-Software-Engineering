using FootballTeamGeneratorV2.Common;
using System;

namespace FootballTeamGeneratorV2.Model
{
    public class Stats
    {
        //Constants & Messages
        private const int MIN_STAT = 0;
        private const int MAX_STAT = 100;
        private const double STATS_CNT = 5;

        //Fields
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        //Constructors
        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        //Properties
        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            protected set
            {
                this.ValidateStat(value, nameof(Endurance));
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            protected set
            {
                this.ValidateStat(value, nameof(Sprint));
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            protected set
            {
                this.ValidateStat(value, nameof(Dribble));
                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            protected set
            {
                this.ValidateStat(value, nameof(Passing));
                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            protected set
            {
                this.ValidateStat(value, nameof(Shooting));
                this.shooting = value;
            }
        }
        public double AverageStats => ((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / STATS_CNT);

        //Methods
        private void ValidateStat(int value, string name)
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException(string.Format(GlobalConstants.InvalidStatExcMsg, name, MIN_STAT, MAX_STAT));
            }
        }
    }
}
