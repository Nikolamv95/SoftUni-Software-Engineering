using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace listOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listNum = Console.ReadLine()
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
                    case "add":
                        listNum.Add(int.Parse(operation[1]));
                        break;
                    case "insert":
                        int index = int.Parse(operation[2]);
                        int numberToIns = int.Parse(operation[1]);

                        if (IsValidIndex(index, listNum.Count))
                        {
                            Console.WriteLine($"Invalid index");
                        }
                        else
                        {
                            listNum.Insert(index, numberToIns);
                        }
                        break;
                    case "remove":
                        int index2 = int.Parse(operation[1]);

                        if (IsValidIndex(index2, listNum.Count))
                        {
                            Console.WriteLine($"Invalid index");
                        }
                        else
                        {
                            listNum.RemoveAt(index2);
                        }
                        break;

                    case "shift":
                        if (operation[1] == "right")
                        {
                            for (int i = int.Parse(operation[2]); i > 0; i--)
                            {
                                    int j = listNum.Count - 1;
                                    int lastNum = listNum[j];
                                    listNum.Insert(0, lastNum);
                                    int removeNum = listNum.Count - 1;
                                    listNum.RemoveAt(removeNum);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < int.Parse(operation[2]); i++)
                            {
                                int firstNum = listNum[0];
                                listNum.Add(firstNum);
                                listNum.RemoveAt(0);
                            }
                        }
                        break;
                }
                operation = Console.ReadLine()
                                .ToLower()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
            }
            Console.WriteLine(string.Join(' ', listNum));
        }

        public static bool IsValidIndex(int index, int lenght)
        {

            return index > lenght || index < 0;
        }
    }
}
