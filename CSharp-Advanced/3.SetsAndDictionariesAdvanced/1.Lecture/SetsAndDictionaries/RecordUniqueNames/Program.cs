using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            HashSet<string> setOfNames = new HashSet<string>();

            for (int i = 0; i < rows; i++)
            {
                string name = Console.ReadLine();
                setOfNames.Add(name);
            }

            foreach (var item in setOfNames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
