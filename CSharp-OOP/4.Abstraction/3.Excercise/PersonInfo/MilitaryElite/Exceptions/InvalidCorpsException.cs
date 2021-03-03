using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        public const string INV_CORPS_EXC = "Invalid corps!";
        public InvalidCorpsException() 
            : base(INV_CORPS_EXC)
        {
        }

        public InvalidCorpsException(string message) 
            : base(message)
        {

        }
        


    }
}
