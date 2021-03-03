using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    internal class GenericEnumerator<T> : IEnumerator<T>
    {
        private readonly List<T> list;
        private int currIndex = -1;

        public GenericEnumerator(List<T> list)
        {
            this.list = list;
        }

        public T Current => list[currIndex];

        object IEnumerator.Current => list[currIndex];

        public void Dispose()
        {
           
        }

        public bool MoveNext()
        {
            currIndex++;
            return currIndex < list.Count;
        }

        public void Reset()
        {
            currIndex -= -1;
        }
    }
}