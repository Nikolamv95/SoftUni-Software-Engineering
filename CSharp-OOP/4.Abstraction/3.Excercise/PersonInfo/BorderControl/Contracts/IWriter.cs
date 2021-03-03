using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
