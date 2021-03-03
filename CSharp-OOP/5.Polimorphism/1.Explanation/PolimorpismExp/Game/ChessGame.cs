using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class ChessGame : Game
    {
        public override void Start()
        {
            this.StartDate = DateTime.Now;
        }

        public override void Stop()
        {
            this.EndDate = DateTime.Now;
        }
    }
}
