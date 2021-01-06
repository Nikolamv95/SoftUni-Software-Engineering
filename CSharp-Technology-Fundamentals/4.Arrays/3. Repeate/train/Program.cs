using System;
using System.Collections.Generic;
using System.Linq;

namespace train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            List<int> passagers = new List<int>();

            for (int i = 0; i < wagons; i++)
            {
                passagers.Add(int.Parse(Console.ReadLine()));
            }
            int sum = passagers.Sum();
            Console.WriteLine(string.Join(' ', passagers));
            Console.WriteLine(sum);
        }
    }
}
