using System;
using System.Linq;
using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Models
{
    class Smartphone : ICallable, IWebBrowsable
    {
        public Smartphone()
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
        public string Browsing(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidUrlException();
            }
            return $"Browsing... {url}";
        }        
    }
}
