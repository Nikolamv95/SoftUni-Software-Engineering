using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualsAndOverride
{
    class Child : Person
    {
        public sealed override void Sleep()
        {
            Console.WriteLine("Dreaming of friends");
        }
    }
}
