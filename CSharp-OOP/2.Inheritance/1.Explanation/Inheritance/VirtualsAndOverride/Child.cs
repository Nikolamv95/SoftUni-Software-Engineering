using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualsAndOverride
{
    class Child : Person
    {
        public override void Sleep()
        {
            Console.WriteLine("Dreaming of friends");
        }
    }
}
