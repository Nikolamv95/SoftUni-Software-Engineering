using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Commons
{
    public class GlobalConstants
    {
        //User
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;

        //Trip
        public const int SeatsMinValue = 2;
        public const int SeatsMaxValue = 6;
        public const int DescriptionMaxLength = 80;
    }
}
