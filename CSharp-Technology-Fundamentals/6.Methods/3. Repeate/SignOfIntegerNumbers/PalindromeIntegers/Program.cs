using System;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            

            Calculation(input);
        }

        private static void Calculation(string input)
        {
            bool isPalindrome = false;
            int lastIndex = 0;

            while (input != "END")
            {
                char[] charArray = input.ToCharArray();
                lastIndex = charArray.Length;

                if (charArray.Length > 1)
                {
                    if (charArray[0] == charArray[lastIndex-1])
                    {
                        isPalindrome = true;
                    }
                    else
                    {
                        isPalindrome = false;
                    }
                }
                else
                {
                    isPalindrome = true;
                }

                Console.WriteLine(isPalindrome);
                input = Console.ReadLine();
            }
        }
    }
}
