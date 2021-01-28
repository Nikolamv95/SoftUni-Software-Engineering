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
            Stack<string> sequence = new Stack<string>(input
                                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                       .Reverse());

            while (sequence.Count > 1)
            {
                string data1 = sequence.Pop();
                string operand = sequence.Pop();
                string data2 = sequence.Pop();

                int result = 0;
                if (operand == "+")
                {
                    result = int.Parse(data1) + int.Parse(data2);
                }
                else
                {
                    result = int.Parse(data1) - int.Parse(data2);
                }
                sequence.Push(result.ToString());
            }
            Console.WriteLine(sequence.Pop());

        }
    }
}
