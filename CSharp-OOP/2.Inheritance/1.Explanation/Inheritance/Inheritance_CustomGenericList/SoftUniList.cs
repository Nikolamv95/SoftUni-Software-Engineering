using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_CustomGenericList
{
    class SoftUniList<T> : GenericList<T>
    {
        public void Add(T item)
        {
            Console.WriteLine("adding elements");
            base.Add(item);
        }

    }
}
