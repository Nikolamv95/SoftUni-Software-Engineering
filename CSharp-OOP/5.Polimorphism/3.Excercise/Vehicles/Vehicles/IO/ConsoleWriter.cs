using System;
using System.Collections.Generic;
using System.Text;
using VehiclesV2.IO.Contracts;

namespace VehiclesV2.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
