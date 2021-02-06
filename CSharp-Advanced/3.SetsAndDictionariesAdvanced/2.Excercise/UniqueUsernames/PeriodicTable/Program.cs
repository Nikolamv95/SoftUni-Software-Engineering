using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> setChemicals = new SortedSet<string>();
            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                string[] chemics = Console.ReadLine().Split().ToArray();

                for (int c = 0; c < chemics.Length; c++)
                {
                    setChemicals.Add(chemics[c]);
                }
            }

            Console.WriteLine(string.Join(' ', setChemicals));
        }
    }
}
