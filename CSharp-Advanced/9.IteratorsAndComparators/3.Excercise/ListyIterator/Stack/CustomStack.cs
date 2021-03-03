using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    class CustomStack<T> : IEnumerable<T>
    {
        private const int capacity = 4;
        private T[] stack;
        public int Count { get; set; }

        public CustomStack()
        {
            this.stack = new T[capacity];
            this.Count = 0;
        }

        public void Pop()
        {
            try
            {
                if (this.Count * 4 < this.stack.Length)
                {
                    Shrink();
                }

                var result = this.stack[this.Count - 1];
                this.stack[this.Count - 1] = default(T);
                this.Count--;
            }
            catch
            {

                Console.WriteLine("No elements");
            }
        }

        private void Shrink()
        {
            T[] newArray = new T[this.stack.Length / 2];
            Array.Copy(this.stack, newArray, this.stack.Length);
            this.stack = newArray;
        }

        public void Push(T items)
        {
                    
            if (this.stack.Length <= this.Count)
            {
                DoubleLength();
            }

            this.stack[this.Count] = items;
            this.Count++;
        }

        public void DoubleLength()
        {
            T[] newArray = new T[this.stack.Length * 2];
            Array.Copy(this.stack, newArray, this.stack.Length);
            this.stack = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> currList = new List<T>();

            for (int i = this.Count-1; i >= 0; i--)
            {
                currList.Add(this.stack[i]);
            }

            return new GenericEnumerator<T>(currList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
