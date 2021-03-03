using System;

namespace LazyInitializationPattern
{
    class Program
    {
        //The program will create the object after someone whants to use it.
        static void Main(string[] args)
        {
            //Lazy<Object>
            Lazy<Cart> cart = new Lazy<Cart>(()=> new Cart (50));
            Console.WriteLine("Currently looking home page");

            //Here the program will make an instance of the object and will reade the balance
            Console.WriteLine(cart.Value.Balance);

        }
    }
}
