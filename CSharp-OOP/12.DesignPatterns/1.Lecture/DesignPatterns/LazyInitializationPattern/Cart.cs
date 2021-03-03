using System;
using System.Collections.Generic;
using System.Text;

namespace LazyInitializationPattern
{
    public class Cart
    {
        public Cart(int balance)
        {
            Console.WriteLine("Initialized");
            this.Balance = balance;
        }

        public int Balance { get; private set; }
    }
}
