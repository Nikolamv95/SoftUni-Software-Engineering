using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosePrinciple
{
    public interface ISortingStrategy
    {
        ICollection<int> Sort(ICollection<int> collection);
    }
}
