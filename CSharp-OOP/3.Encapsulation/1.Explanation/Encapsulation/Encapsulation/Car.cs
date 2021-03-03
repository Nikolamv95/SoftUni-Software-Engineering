using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
    class Car
    {
        public Engine Engine { get; set; }
        public SpeedStats SpeedStats { get; set; }
        public Tyres Tyres { get; set; }

        public void Start()
        {
            Engine.Start();
            SpeedStats.StopWatching();
            
            if (Tyres.IsRubbis())
            {
                //DO SOMETHING
            }
        }

        public void Stop()
        {
            Engine.Stop();
            SpeedStats.StopWatching();
        }

        public void PressPedal(long amount)
        {

        }

    }
}
