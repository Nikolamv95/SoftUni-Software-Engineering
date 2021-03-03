using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClass
{
    abstract class Worker
    {
        public abstract int MyProperty { get; set; }

        //Този метод казва, децата ми които ме наследяват трябва да разпишат логика за този метод задължително
        public abstract void Work();
    }
}
