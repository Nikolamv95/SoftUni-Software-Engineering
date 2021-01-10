using System;

namespace passwordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            char[] charPassword = password.ToCharArray();
            PasswordCheck(charPassword);
        }

        private static void PasswordCheck(char[] charPassword)
        {
            bool result6To10 = To10CheckPass(charPassword);
            bool resultLetters = LettersCheckPass(charPassword);
            bool result2Digits = DigitsCheckPass(charPassword);

            if (result6To10 && resultLetters && result2Digits)
            {
                Console.WriteLine("Password is valid");
            }
            if (!result6To10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!resultLetters)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!result2Digits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        private static bool DigitsCheckPass(char[] charPassword)
        {
            int counter = 0;
            bool result2Digits = false;

            for (int i = 0; i < charPassword.Length; i++)
            {
                if (char.IsDigit(charPassword[i]))
                {
                    counter++;
                }
            }

            if (counter >= 2)
            {
                result2Digits = true;
            }

            return result2Digits;
        }

        private static bool LettersCheckPass(char[] charPassword)
        {
            bool resultLetters = false;

            for (int i = 0; i < charPassword.Length; i++)
            {
                if (char.IsDigit(charPassword[i]) || char.IsLetter(charPassword[i]))
                {
                    resultLetters = true;
                }
                else
                {
                    resultLetters = false;
                    break;
                }
            }

            return resultLetters;
        }

        private static bool To10CheckPass(char[] charPassword)
        {
            int counter = 0;
            bool result6To10 = false;

            for (int i = 0; i < charPassword.Length; i++)
            {
                counter++;
            }

            if (counter >= 6 && counter <= 10)
            {
                result6To10 = true;
            }

            return result6To10;
        }
    }
}
