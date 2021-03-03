using System;
using System.Collections.Generic;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> array = new int[] { 1, 2, 3, 4, 5 };

            foreach (var item in array)
            {
                Console.WriteLine($"Normal foreach {item}");
            }

            //foreach (var item in array) == на IEnumerator<int> enumerator = array.GetEnumerator(); / while (enumerator.MoveNext())
            //зад Foreach стои този код
            //enumerator.Current == item от foreach

            IEnumerator<int> enumerator = array.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine($"Real foreach: {enumerator.Current}");
            }
        }

        ////public interface IEnumerable<T> : IEnumerator
        ////{
        //    Inumerator<T> GetEnumerator();
        // }
    }
}
