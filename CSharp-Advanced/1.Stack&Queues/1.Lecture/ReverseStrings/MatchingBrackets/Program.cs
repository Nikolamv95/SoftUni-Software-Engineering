using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            //Взимаме дължината на инпута
            for (int i = 0; i < input.Length; i++)
            {
                //Записваме в стека индекса на стринга input който съдържа само '('
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                //Записваме в стека индекса на стринга input който съдържа само ')'
                //Стигайки до този символ знаем че израза в скобите е цял
                else if (input[i] == ')')
                {
                    //Взимаме последния индекс който съдържа '(' и с метода Substring печатаме целия израз
                    //като започваме от '(' отварящата скоба и печатаме до затварящата скоба ')'
                    //Взимайки отварящата скоба тя се премахва от стека и остава индекс само ако има предходна отваряща скоба
                    int start = stack.Pop();
                    Console.WriteLine(input.Substring(start, i - start+1));
                }
            }
        }
    }
}
