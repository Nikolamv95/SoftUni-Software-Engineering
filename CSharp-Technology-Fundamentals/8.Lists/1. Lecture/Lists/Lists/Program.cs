using System;
using System.Collections.Generic;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            //Дефиниране на списък със 100 символа
            List <int> a = new List<int>(100);
            a.Add(1);
            a.Insert(1, 10);
            a.Insert(2, 30);

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            //Дефиниране на списък с масив
            List<int> num = new List<int>(new int[] { 5,6,7,8});

        }
    }
}
