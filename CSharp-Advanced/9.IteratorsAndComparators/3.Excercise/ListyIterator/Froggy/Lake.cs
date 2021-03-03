using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    class Lake : IEnumerable<int>
    {
        private const int capacity = 4;
        private int[] stones;
        public int Count { get; set; }

        public Lake()
        {
            this.stones = new int[capacity];
            this.Count = 0;
        }

        public void Push(int items)
        {

            if (this.stones.Length <= this.Count)
            {
                DoubleLength();
            }

            this.stones[this.Count] = items;
            
            this.Count++;
        }

        private void DoubleLength()
        {
            int[] newArray = new int[this.stones.Length * 2];
            Array.Copy(this.stones, newArray, this.stones.Length);
            this.stones = newArray;
        }


        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            List<int> sortedStones = SortedStones();

            return new GenericEnumerator(sortedStones);
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private List<int> SortedStones()
        {
            List<int> sortedStones = new List<int>();

            //Even
            if (this.Count % 2 == 0)
            {
                for (int i = 0; i < this.Count - 1; i += 2)
                {
                    sortedStones.Add(stones[i]);
                }

                for (int i = this.Count-1; i > 0; i -= 2)
                {
                    sortedStones.Add(stones[i]);
                }
            }
            else //Odd
            {
                for (int i = 0; i < this.Count; i += 2)
                {
                    sortedStones.Add(stones[i]);
                }

                for (int i = this.Count-2; i > 0; i -= 2)
                {
                    sortedStones.Add(stones[i]);
                }
            }

            return sortedStones;
        }
    }
}
