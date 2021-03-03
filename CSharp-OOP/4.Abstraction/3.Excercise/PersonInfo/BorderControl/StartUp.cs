﻿using BorderControl.Contracts;
using BorderControl.Core;
using BorderControl.IO;
using System;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            Engine engine = new Engine(reader, writer);
            engine.Run();
            
        }
    }
}
