using SolidLogger.IOManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.IOManagement
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);;
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
