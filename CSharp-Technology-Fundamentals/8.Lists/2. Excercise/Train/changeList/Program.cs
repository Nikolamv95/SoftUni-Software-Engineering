using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();

            string[] operation = Console.ReadLine()
                                .ToLower()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();



            while (operation[0] != "end")
            {

                switch (operation[0])
                {
                    case "delete":
                        int deleteNumbers = int.Parse(operation[1]);
                        numbers.RemoveAll(n => n == deleteNumbers);
                        break;
                    case "insert":
                        int index = int.Parse(operation[2]);
                        int number = int.Parse(operation[1]);
                        numbers.Insert(index, number);
                        break;
                }

                operation = Console.ReadLine()
                                .ToLower() 
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
