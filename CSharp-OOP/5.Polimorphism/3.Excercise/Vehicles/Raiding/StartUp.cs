﻿using Raiding.Core;
using Raiding.Core.Contracts;
using Raiding.IO;
using Raiding.IO.Contracts;

namespace Raiding
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
