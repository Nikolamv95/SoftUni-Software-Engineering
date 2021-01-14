using System;
using System.Collections.Generic;
using System.Linq;

namespace task3
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
            ;
            listOfTopNums.Sort();


            if (listOfTopNums.Count > 5)
            {
                bool isTop5 = false;

                for (int i = 0; i < listOfTopNums.Count; i++)
                {
                    for (int j = 0; j < listOfTopNums.Count; j++)
                    {
                        if (listOfTopNums[i] < listOfTopNums[j + 1])

                        {
                            listOfTopNums.RemoveAt(i);

                            if (listOfTopNums.Count == 5)
                            {
                                isTop5 = true;
                                break;
                            }
                        }
                    }
                    if (isTop5 == true)
                    {
                        break;
                    }
                }

                listOfTopNums.Sort();
                listOfTopNums.Reverse();
                Console.WriteLine(string.Join(' ', listOfTopNums));
            }
            else if (listOfTopNums.Count > 0 && listOfTopNums.Count <= 5)
            {
                listOfTopNums.Sort();
                listOfTopNums.Reverse();
                Console.WriteLine(string.Join(' ', listOfTopNums));
            }
            else if (listOfTopNums.Count == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
