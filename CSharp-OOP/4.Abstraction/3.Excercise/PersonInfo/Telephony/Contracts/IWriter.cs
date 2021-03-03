using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Contracts
{
    interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
