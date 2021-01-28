using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> parenthesStack = new Stack<char>();
            bool isValid = true;

            foreach (var c in input)
            {
                //В if prowerkata към стека добавяме всички отварящи скоби
                if (c == '(' || c == '[' || c == '{')
                {
                    parenthesStack.Push(c);
                }
                else
                {
                    //В else проверката проверяваме дали затварящите скоби отговарят за отварящите

                    //Проверяваме дали в стека има символи които могат да се поискат. Ако няма isValid = false
                    if (!parenthesStack.Any())
                    {
                        isValid = false;
                        break;
                    }

                    //Взимаме първата затваряща скоба и проверяваме тя съвпада ли с някоя от стека.
                    char currOpenBracket = parenthesStack.Pop();

                    //Проверяваме дали един от изразите съвпада (текущия символ да съвпада с този от стринга), винаги трябва да има един true след като ги обходи, за да е
                    //валидно условието и да не влезе в проверката
                    bool isBracket = currOpenBracket == '(' && c == ')';
                    bool isBracketStreight = currOpenBracket == '[' && c == ']';
                    bool isBracketCurly = currOpenBracket == '{' && c == '}';

                    //В тази if Проверка ще се влезе само ако и трите условия са грешни, това означава че при някое
                    //от завъртанията в булевите изразинито едно условия не е било вярно и е нямало изрази които да
                    //са еднакви
                    if (isBracket == false && isBracketStreight == false && isBracketCurly == false)
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}