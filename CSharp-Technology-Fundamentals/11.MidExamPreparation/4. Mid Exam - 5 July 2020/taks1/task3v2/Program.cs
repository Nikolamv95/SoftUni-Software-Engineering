using System;
using System.Collections.Generic;
using System.Linq;

namespace task3v2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            double sum = listOfNumbers.Sum();
            double count = listOfNumbers.Count;
            double averageNum = sum / count;

            List<int> listOfTopNums = new List<int>();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                if (listOfNumbers[i] > averageNum)
                {
                    listOfTopNums.Add(listOfNumbers[i]);
                }
            }


            if (listOfTopNums.Count == 0)
            {
                Console.WriteLine("No");
            }      
            else
            {
                if (listOfTopNums.Count > 4)
                {
                    //Console.WriteLine(string.Join(" ", listOfNumbers.OrderByDescending(x => x).Take(Math.Min(5, listOfNumbers.Count))));

                    List<int> result = new List<int>();

                    for (int i = listOfTopNums.Count; i > 0; i--)
                    {
                        int number = listOfTopNums.OrderByDescending(x => x).Max();
                        listOfTopNums.Remove(number);

                        if (result.Count <= 4)
                        {
                            result.Add(number); 
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.WriteLine(string.Join(' ', result));
                }
                else
                {
                    listOfTopNums.Sort();
                    listOfTopNums.Reverse();
                    Console.WriteLine(string.Join(' ', listOfTopNums));
                }
            }
        }
    }
}
