using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;
        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public Box()
        {
            data = new List<T>();
        }

        public void Add(T element)
        {
            data.Add(element);
        }

        public T Remove()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T result = data[this.Count-1];
            data.RemoveAt(this.Count - 1);

            return result;
        }
    }
}
