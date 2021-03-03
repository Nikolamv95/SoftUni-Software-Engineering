using AbstractedRendering.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AbstractedRendering
{
    class Game
    {
        private List<IGameObject> objects;
        private IDrawer drawer;

        public Game(IDrawer drawer)
        {
            this.drawer = drawer;
            this.objects = new List<IGameObject>();
            this.objects.Add(new Snake());
            this.objects.Add(new Food());
            this.objects.Add(new Food());
            this.objects.Add(new Obstacle());
            this.objects.Add(new Obstacle());
        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(1000);
                foreach (IGameObject item in objects)
                {
                    item.Draw(this.drawer);
                }
            }
        }
    }
}
