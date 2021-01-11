using System;
using System.Collections.Generic;
using System.Linq;

namespace mergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstRow = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            List<string> secondRow = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

           List<string> resultList = MergeList(firstRow, secondRow);

           Console.Write(string.Join(' ', resultList));
        }

        private static List<string> MergeList(List<string> firstRow, List<string> secondRow)
        {
            List<string> resultList = new List<string>();

            if (firstRow.Count >= secondRow.Count)
            {
                for (int firstNum = 0; firstNum < firstRow.Count; firstNum++)
                {
                    resultList.Add(firstRow[firstNum]);
                    
                    if (secondRow.Count > firstNum)
                    {
                        resultList.Add(secondRow[firstNum]);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                    for (int firstNum = 0; firstNum < secondRow.Count; firstNum++)
                    {
                        if (firstRow.Count > firstNum)
                        {
                            resultList.Add(firstRow[firstNum]);
                        }
                        resultList.Add(secondRow[firstNum]);
                    }
            }
            return resultList;
        }
    }
}
