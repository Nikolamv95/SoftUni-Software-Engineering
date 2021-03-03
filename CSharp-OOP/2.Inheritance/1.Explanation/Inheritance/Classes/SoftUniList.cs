using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_Collections_Lists
{
    //SoftUniLIst<T> наследява List<T> и може да използва всичките му функционалности
    class SoftUniList<T> : List<T>
    {
        public void Add(T item)
        {
            Console.WriteLine("Adding elements rulz " + item);
            base.Add(item);
        }
    }
}
