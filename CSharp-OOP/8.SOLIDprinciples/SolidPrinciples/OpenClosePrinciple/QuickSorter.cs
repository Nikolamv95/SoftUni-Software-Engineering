using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosePrinciple
{
    public class QuickSorter : ISortingStrategy
    {
        public ICollection<int> Sort(ICollection<int> collection)
        {
            Console.WriteLine("QuickSorter logic");
            return collection;
        }
    }
}
