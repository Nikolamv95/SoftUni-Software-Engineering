using System;
using System.Collections.Generic;

namespace OpenClosePrinciple
{
    public class StartUp 
    {
        static void Main(string[] args)
        {
            Sorter sorter = new Sorter();
            sorter.Sort(new List<int>(), Console.ReadLine());
        }
    }
}
