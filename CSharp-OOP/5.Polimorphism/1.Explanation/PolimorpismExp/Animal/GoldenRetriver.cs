using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    public class GoldenRetriver : Dog
    {
        public override void Eat(object food)
        {
            Console.WriteLine("Golder Retriver - eat"); ;
        }

        public override void Sleep()
        {
            Console.WriteLine("Golder Retriver - sleep");
        }
    }
}
