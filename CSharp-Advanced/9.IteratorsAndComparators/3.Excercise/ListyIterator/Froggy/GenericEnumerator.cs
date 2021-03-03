using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class GenericEnumerator : IEnumerator<int>
    {
        private List<int> stones;
        private int currIndex = -1;

        public GenericEnumerator(List<int> stones)
        {
            this.stones = stones;
        }

        public int Current => this.stones[currIndex];

        object IEnumerator.Current => this.stones[currIndex];

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            currIndex++;
            return currIndex < stones.Count;
        }

        public void Reset()
        {
            currIndex = -1;
        }
    }
}