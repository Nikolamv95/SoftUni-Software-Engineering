using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosePrinciple
{
    public class MergeSorter : ISortingStrategy
    {
        public ICollection<int> Sort(ICollection<int> collection)
        {
            Console.WriteLine("MergeSort logic");
            return collection;
        }
    }
}
