using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> currChar = new Stack<char>();

            var chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                currChar.Push(chars[i]);
            }

            while (currChar.Count > 0)
            {
                Console.Write(currChar.Pop());
            }
        }
    }
}
