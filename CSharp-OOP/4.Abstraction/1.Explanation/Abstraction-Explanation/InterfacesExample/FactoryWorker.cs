using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesExample
{
    class FactoryWorker : IWorker
    {
        public void GetSalary()
        {
            Console.WriteLine("Always");
        }

        public void Work()
        {
            Console.WriteLine("Hustle hard");
        }
    }
}
