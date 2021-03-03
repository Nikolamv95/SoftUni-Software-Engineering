using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesExample
{
    class Programmer : IWorker
    {
        public void GetSalary()
        {
            Console.WriteLine("Slacking all day");
        }

        public void Work()
        {
            Console.WriteLine("Underserved");
        }
    }
}
