using SolidLogger.IOManagement.Contracts;
using System;

namespace SolidLogger.IOManagement
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
