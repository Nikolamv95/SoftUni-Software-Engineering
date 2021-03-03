using AbstractedRendering.Contracts;
using AbstractedRendering.Drawers;
using System;

namespace AbstractedRendering
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ConsoleDrawer drawer = new ConsoleDrawer();
            Game game = new Game(drawer);
            game.Start();
        }
    }
}
