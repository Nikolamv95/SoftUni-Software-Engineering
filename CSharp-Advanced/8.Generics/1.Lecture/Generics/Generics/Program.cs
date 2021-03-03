using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var myGenericListInt = CreateList<int>(9);
            var stringLIst = CreateList<string>("Pesho");
        }

        static List<T> CreateList<T>(T element)
        {
            return new List<T>() { element };
        }
    }
}
