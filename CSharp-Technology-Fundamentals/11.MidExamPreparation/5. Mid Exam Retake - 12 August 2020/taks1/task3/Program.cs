using System;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfElements = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .ToList();

            string input = string.Empty;
            int numMoves = 0;
            bool isFinished = true;

            while ((input = Console.ReadLine()) != "end")
            {
                int[] data = input
                              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

                numMoves++;

                int index1 = data[0];
                int index2 = data[1];

                if (index1 == index2 //Провери После
                                    || index1 < 0 || index1 > listOfElements.Count - 1
                                    || index2 < 0 || index2 > listOfElements.Count - 1)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    int mid = listOfElements.Count / 2;

                    if (mid % 2 == 0)
                    {
                        string addElement = $"-{numMoves}a";
                        listOfElements.Insert(mid, addElement);
                        listOfElements.Insert(mid, addElement);
                    }
                    else
                    {
                        string addElement = $"-{numMoves}a";
                        listOfElements.Insert(mid, addElement);
                        listOfElements.Insert(mid, addElement);
                    }
                }

                else if (index1 != index2 && (index1 >= 0 && index1 < listOfElements.Count) && (index2 >= 0 && index2 < listOfElements.Count))
                {                           
                                            
                
                    string element1 = listOfElements[index1];
                    string element2 = listOfElements[index2];

                    if (element1 == element2)
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {element1}!");
                        listOfElements.Remove(element1);
                        listOfElements.Remove(element2);

                    }
                    else if (element1 != element2)
                    {
                        Console.WriteLine("Try again!");
                    }
                }

                if (listOfElements.Count == 0)
                {
                    isFinished = true;
                    break;
                }
                else
                {
                    isFinished = false;
                }
            }

            if (isFinished == true)
            {
                Console.WriteLine($"You have won in {numMoves} turns!");
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(' ', listOfElements));
            }
        }
    }
}
