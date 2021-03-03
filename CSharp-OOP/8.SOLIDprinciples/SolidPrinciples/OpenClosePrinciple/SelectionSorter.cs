using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosePrinciple
{
    public class SelectionSorter : ISortingStrategy
    {
        public ICollection<int> Sort(ICollection<int> collection)
        {
            Console.WriteLine("SelectionSorter logic");
            return collection;
        }
    }
}
