using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public abstract class Game
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public abstract void Start();
        public abstract void Stop();
    }
}
