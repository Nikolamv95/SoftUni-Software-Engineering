using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxОfString
{
    public class Box<T>
    {
        ////Set value
        //private readonly T value;

        //public Box(T value)
        //{
        //    this.value = value;
        //}
        ////Get value
        //public T Value => this.value;

        public Box(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }

    }
}
