using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<string> stack = new Stack<string>(input
                                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries));

            string command = string.Empty;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string [] data = command.Split(' ').ToArray();

                if (data[0] == "add")
                {
                    stack.Push(data[1]);
                    stack.Push(data[2]);
                }
                else if (data[0] == "remove")
                {
                    if (stack.Count > int.Parse(data[1]))
                    {
                        for (int i = 0; i < int.Parse(data[1]); i++)
                        {
                            stack.Pop();
                        }
                    }
                    
                }
            }

            while (stack.Count > 1)
            {
                int number1 = int.Parse(stack.Pop());
                int number2 = int.Parse(stack.Pop());

                int result = number1 + number2;

                stack.Push(result.ToString());
            }

            Console.WriteLine($"Sum: {stack.Pop()}");
        }
    }
}
