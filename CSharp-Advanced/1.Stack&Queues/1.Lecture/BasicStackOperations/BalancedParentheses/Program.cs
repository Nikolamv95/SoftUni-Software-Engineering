using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            char[] charArray = expression.ToCharArray();

            Stack<char> stackOfCharsFirst = new Stack<char>();
            Stack<char> stackOfCharsSecond = new Stack<char>();

            foreach (char c in charArray)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stackOfCharsFirst.Push(c);
                }
            }

            foreach (char c in charArray.Reverse())
            {
                if (c == ')' || c == ']' || c == '}')
                {
                    stackOfCharsSecond.Push(c);
                }
            }

            if (stackOfCharsFirst.Count == stackOfCharsSecond.Count)
            {
                bool isValid = true;

                while (true)
                {
                    if (stackOfCharsFirst.Count > 0 && stackOfCharsSecond.Count > 0)
                    {
                        char firstStackCharr = stackOfCharsFirst.Pop();
                        char secondStackCharr = stackOfCharsSecond.Pop();

                        bool isBracket = firstStackCharr == '(' && secondStackCharr == ')';
                        bool isBracketStreight = firstStackCharr == '[' && secondStackCharr == ']';
                        bool isBracketCurly = firstStackCharr == '{' && secondStackCharr == '}';


                        if (isBracket || isBracketStreight || isBracketCurly)
                        {
                            continue;
                        }
                        else
                        {
                            isValid = false;
                            Console.WriteLine("NO");
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (isValid)
                {
                    Console.WriteLine("YES");
                }
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
