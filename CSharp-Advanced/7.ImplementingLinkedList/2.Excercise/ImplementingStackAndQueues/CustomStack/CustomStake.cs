using System;

namespace CustomStack
{
    class CustomStake
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public int Count { get; private set; }

        public CustomStake()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }

        public int Peek()
        {
            int value = this.items[this.Count - 1];
            return value;
        }

        public int Pop()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Custom stakck is empty");
            }

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            int value = this.items[this.Count - 1];
            this.items[this.Count - 1] = default(int);
            Count--;

            return value;
        }

        private void Shrink()
        {
            int[] shrinkArray = new int[this.items.Length / 2];
            Array.Copy(this.items, shrinkArray, this.Count);
            this.items = shrinkArray;

        }

        public void Push(int item)
        {

            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[this.Count++] = item;
        }

        private void Resize()
        {
            int[] newTemp = new int[this.items.Length * 2];
            Array.Copy(this.items, newTemp, this.items.Length);
            this.items = newTemp;
        }
    }
}
