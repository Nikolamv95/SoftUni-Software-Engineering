using System;
using System.Linq;

using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Models
{
    class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {
           
        }

        public string Calling(string num)
        {
            if (!num.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }
           return $"Calling... {num}";
        }
    }
}
