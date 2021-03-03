using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<int> myStack = new CustomStack<int>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command.Contains("Push"))
                {
                    command = command.Remove(0, 5);
                    List<int> currList = command.Split(", ").Select(int.Parse).ToList();
                    for (int i = 0; i < currList.Count; i++)
                    {
                        myStack.Push(currList[i]);
                    }
                }
                else if (command.Contains("Pop"))
                {
                    myStack.Pop();
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in myStack)
                {
                    Console.WriteLine(item);
                }
            }
            
        }
    }
}
