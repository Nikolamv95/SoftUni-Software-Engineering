using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesExample
{
    class Boss : IManager //както при наследяването Boss наследява IManager който има IWorker в себе си
    {
        public List<IManager> Team { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GetSalary()
        {
            Console.WriteLine("A lot");
        }

        public void Work()
        {
            Console.WriteLine("Top quality");
        }
    }
}
