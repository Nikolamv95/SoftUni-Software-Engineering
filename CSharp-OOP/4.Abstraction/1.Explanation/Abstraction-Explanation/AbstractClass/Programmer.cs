using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClass
{
    class Programmer : Worker
    {
        public override int MyProperty { get ; set ; }

        //Наследява abstract method Work и е задължително да го имплементираш в текущия клас
        public override void Work()
        {
            Console.WriteLine("Slacking all day");
        }
    }
}
