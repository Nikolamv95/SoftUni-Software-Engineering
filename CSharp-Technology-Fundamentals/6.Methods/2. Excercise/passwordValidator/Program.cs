using System;
using System.Text.RegularExpressions;

namespace passwordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isFrom6to10 = false;
            bool onlyLetAndDig = false;
            bool atLeast2Dig = false;

           isFrom6to10 = Characters6To10(password);
           onlyLetAndDig = OnlyLetterAndDigits(password);
           atLeast2Dig = atLeast2Digits(password);

            if (isFrom6to10 == true && onlyLetAndDig == true && atLeast2Dig == true)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (isFrom6to10 == false)
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (onlyLetAndDig == false)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (atLeast2Dig == false)
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }

        static bool Characters6To10(string password)
        {
            int counter = 0;
            bool isFrom6to10 = false;

            for (int i = 1; i <= password.Length; i++)
            {
                counter += 1;
            }

            if (counter >= 6 && counter <= 10)
            {
                isFrom6to10 = true;
            }

            return isFrom6to10;
        }

        static bool OnlyLetterAndDigits(string password)
        {
            bool onlyLetAndDig = false;

            if (Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
            {
                onlyLetAndDig = true;
            }
            
            return onlyLetAndDig;
        }

        static bool atLeast2Digits(string password)
        {
            bool atLeast2Dig = false;
            int counter = 0;

            foreach (char @char in password)
            {
                if (@char >= '0' && @char <= '9')
                {
                    counter += 1;
                }
            }

            if (counter >= 2)
            {
                atLeast2Dig = true;
            }

            return atLeast2Dig;
        }
    }
}
