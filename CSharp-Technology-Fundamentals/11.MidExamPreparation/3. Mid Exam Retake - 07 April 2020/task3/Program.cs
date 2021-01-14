using System;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfTargets = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

                string operation = command[0];
                int index = int.Parse(command[1]);
                int number = int.Parse(command[2]);

                switch (operation)
                {
                    case "Shoot":                     
                        if (index >= 0 && index < listOfTargets.Count)
                        {
                            listOfTargets[index] -= number;

                            if (listOfTargets[index] <= 0)
                            {
                                listOfTargets.RemoveAt(index);
                            }
                        }
                        break;
                    case "Add":                          
                        if (index >= 0 && index < listOfTargets.Count)
                        {
                            listOfTargets.Insert(index, number);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;
                    case "Strike":
                        int indexToDelLeft = number;
                        int indexToDelRight = number;
                        int total = indexToDelLeft + indexToDelRight + 1;
                        //Провери после Още един път
                        if (index - indexToDelLeft >= 0 && index + indexToDelRight < listOfTargets.Count)
                        {

                            listOfTargets.RemoveRange(index-indexToDelLeft, indexToDelLeft*2 + 1);
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join("|", listOfTargets));
        }
    }
}
