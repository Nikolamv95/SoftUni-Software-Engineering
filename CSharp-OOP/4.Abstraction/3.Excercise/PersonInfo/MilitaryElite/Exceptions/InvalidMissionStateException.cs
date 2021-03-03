using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionStateException : Exception
    {
        public const string INV_MISSION_EXP = "Invalid mission state!";

        public InvalidMissionStateException() : base(INV_MISSION_EXP)
        {
        }

        public InvalidMissionStateException(string message) 
            : base(message)
        {
        }
    }
}
