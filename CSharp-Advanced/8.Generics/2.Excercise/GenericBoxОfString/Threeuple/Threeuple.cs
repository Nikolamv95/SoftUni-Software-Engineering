using System;

namespace Threeuple
{
    public class Threeuple<T, V, K> where K : IComparable
    {
        public Threeuple(T item1, V item2, K item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public T Item1 { get; set; }
        public V Item2 { get; set; }
        public K Item3 { get; set; }


        public string DrunkOrNot()
        {

            int result1 = this.Item3.CompareTo("not");

            if (result1 == 0)
            {
                return $"{this.Item1} -> {this.Item2} -> False";
            }

            return $"{this.Item1} -> {this.Item2} -> True";
        }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}
