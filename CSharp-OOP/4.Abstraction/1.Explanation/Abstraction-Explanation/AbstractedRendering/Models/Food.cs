using AbstractedRendering.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractedRendering
{
    class Food : IGameObject
    {
        public bool IsEaten { get; set; }

        public void Draw(IDrawer iDrawer)
        {
            iDrawer.WriteLine("I`m food, eat me");
        }
    }
}
