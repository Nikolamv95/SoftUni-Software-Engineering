using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionCompleatedException : Exception
    {
        public const string INV_MISSION_EXC= "Mission already completed!";
        public InvalidMissionCompleatedException() 
            : base(INV_MISSION_EXC)
        {
        }

        public InvalidMissionCompleatedException(string message) 
            : base(message)
        {
        }
    }
}
