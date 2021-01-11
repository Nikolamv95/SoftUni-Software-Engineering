using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace listManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            string[] command = Console.ReadLine()
                                .ToLower()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            bool isChanged = false;

            StringBuilder output = new StringBuilder(); 

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    //Task 1
                    case "add":
                        numbers.Add(int.Parse(command[1]));
                        isChanged = true;
                        break;
                    case "remove":
                        numbers.Remove(int.Parse(command[1]));
                        isChanged = true;
                        break;
                    case "removeat":
                        numbers.RemoveAt(int.Parse(command[1]));
                        isChanged = true;
                        break;
                    case "insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        isChanged = true;
                        break;

                        //Task 2
                    case "contains":
                        output.AppendLine(numbers.Contains(int.Parse(command[1]))
                                          ? "Yes" : "No such number"); 
                        break;
                    case "printeven":
                        output.AppendLine(string.Join(' ', 
                                         numbers.Where(even => even % 2 == 0)));
                        break;
                    case "printodd":
                        output.AppendLine(string.Join(' ',
                                         numbers.Where(even => even % 2 != 0)));
                        break;
                    case "getsum":
                        output.AppendLine(numbers.Sum().ToString());
                        break;
                    case "filter":
                        string result = String.Empty;
                        switch (command[1])
                        {
                            case "<":
                                result = string.Join(" ", numbers.Where(small => small < int.Parse(command[2])));
                                break;
                            case "<=":
                                result = string.Join(" ", numbers.Where(small => small <= int.Parse(command[2])));
                                break;
                            case ">":
                                result = string.Join(" ", numbers.Where(small => small > int.Parse(command[2])));
                                break;
                            case ">=":
                                result = string.Join(" ", numbers.Where(small => small >= int.Parse(command[2])));
                                break;
                        }
                        output.AppendLine(result);
                        break;
                }
                command = Console.ReadLine()
                                 .ToLower()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(output.ToString());

            if (isChanged == true)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}
