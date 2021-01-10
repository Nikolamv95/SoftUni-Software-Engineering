using System;

namespace vowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            char[] letters = input.ToCharArray();

            int result = 0;
            result = Operation(letters);

            Console.WriteLine(result);
        }

        static int Operation(char[] letters)
        {
            int result = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == 'a' || letters[i] == 'e' || letters[i] == 'i'
                    || letters[i] == 'o' || letters[i] == 'o' || letters[i] == 'u')
                {
                    result += 1;
                }
            }

            return result;
        }
    }
}
