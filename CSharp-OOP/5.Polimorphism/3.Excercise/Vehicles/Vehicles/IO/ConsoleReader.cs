using System;
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
