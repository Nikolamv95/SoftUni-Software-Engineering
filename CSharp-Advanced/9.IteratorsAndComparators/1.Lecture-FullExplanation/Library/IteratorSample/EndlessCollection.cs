using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorSample
{
    //Тук направихме EndlessCollection Който е IEnumerable<int>
    class EndlessCollection : IEnumerable<int>
    {
        //Той връща нов Iterator -> EndlessEnumerator, като отива в метода MoveNext() и връща ново рандом число
        public IEnumerator<int> GetEnumerator()
        {
            return new EndlessEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
