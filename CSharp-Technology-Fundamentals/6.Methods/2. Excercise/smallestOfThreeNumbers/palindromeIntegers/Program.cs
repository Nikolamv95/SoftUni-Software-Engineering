using System;
using System.Linq;

namespace palindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                bool isPalindrome = Calculation(input);
                string finalResult = "";

                if (isPalindrome == true)
                {
                    finalResult = "true";
                }
                else
                {
                    finalResult = "false";
                }

                Console.WriteLine(finalResult);
                
                input = Console.ReadLine();
            }
            
        }

        static bool Calculation(string input)
        {
            bool IsPalindrome = false;
            string reversedWord = null;

            for (int i = input.Length-1; i >= 0; i--)
            {
                reversedWord += input[i];
            }

            if (input == reversedWord)
            {
                IsPalindrome = true;
            }

            return IsPalindrome;
        }
    }
}
