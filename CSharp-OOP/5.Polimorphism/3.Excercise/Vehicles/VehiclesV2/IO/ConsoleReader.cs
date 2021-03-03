using System;
using System.Collections.Generic;
using System.Text;
using VehiclesV2.IO.Contracts;

namespace VehiclesV2.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
