using AbstractedRendering.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractedRendering
{
    class Snake : IGameObject
    {
        public void Draw(IDrawer iDrawer)
        {
            iDrawer.WriteLine("I`m a snake");
        }
    }
}
