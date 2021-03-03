using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    //public class EqualityScale<T,V> where T : class where V : struct двете стойности наследяват различни данни
    {
        private readonly T left;
        private readonly T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        
        public bool AreEqual()
        {
            return left.Equals(right);
        }
    }
}
