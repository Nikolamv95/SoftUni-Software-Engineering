using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGeneratorV2.Common
{
    public class GlobalConstants
    {
        public const string InvalidStatExcMsg = "{0} should be between {1} and {2}.";
        public const string InvalidNameExcMsg = "A name should not be empty.";
        public const string PlayerDontExistExcMsg = "Player {0} is not in {1} team.";
        public const string TeamDontExistExcMsg = "Team {0} does not exist.";
    }
}
