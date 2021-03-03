using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualsAndOverride
{
    class Person
    {
        public virtual void Sleep()
        {
            Console.WriteLine("Sleeping OK");
        }
    }
}
