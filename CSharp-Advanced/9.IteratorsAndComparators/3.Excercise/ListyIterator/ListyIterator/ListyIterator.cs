using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private int currIndex;
        private List<T> items;

        public ListyIterator(List<T>initialItems)
        {
            this.currIndex = 0;
            this.items = initialItems;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool HasNext()
        {  
            if (currIndex < items.Count-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Move()
        {
            

            if (HasNext() == true)
            {
                currIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(items[currIndex]);
            }
            catch
            {

                Console.WriteLine("Invalid Operation!");
            }
        }        
    }
}
