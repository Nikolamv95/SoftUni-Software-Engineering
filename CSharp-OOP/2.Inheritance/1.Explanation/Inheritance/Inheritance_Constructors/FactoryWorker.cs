using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class FactoryWorker : Worker
    {
        public FactoryWorker()
        {

        }

        public FactoryWorker(string company) : base(company)
        {
            
        }

        public FactoryWorker(string name, int age, string company) : base(name, age, company)
        {
            
           
        }

        public void LeaveFactory()
        {
            Console.WriteLine("He Left the game");
        }
    }
}
