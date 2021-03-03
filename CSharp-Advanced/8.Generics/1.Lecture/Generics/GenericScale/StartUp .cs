using System;

namespace GenericScale
{
    class Program
    {
        static void Main(string[] args)
        {
            var intEqu = new EqualityScale<int>(5, 8);
            var intEqu2 = new EqualityScale<string>("Pesho", "Pesho");

            Console.WriteLine(intEqu.AreEqual());
            Console.WriteLine(intEqu2.AreEqual());
        }
    }
}
