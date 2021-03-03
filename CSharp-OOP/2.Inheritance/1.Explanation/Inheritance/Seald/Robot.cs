using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualsAndOverride
{
    class Robot : Person
    {
        public override void Sleep()
        {
            throw new ArgumentException("Ne Spiiii");
        }
    }
}
