using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int namesCount = int.Parse(Console.ReadLine());
            List<string> namesArr = Console.ReadLine().Split().ToList();
            Func<string, bool> nameLegth = x => x.Length <= namesCount;
            namesArr = namesArr.Where(nameLegth).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, namesArr));
        }
    }
}
