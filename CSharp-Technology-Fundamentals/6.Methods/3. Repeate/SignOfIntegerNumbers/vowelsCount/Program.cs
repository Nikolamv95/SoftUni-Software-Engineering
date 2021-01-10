using System;

namespace vowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            char[] charArray = input.ToCharArray();

            int result = vowelsCount(charArray);
            Console.WriteLine(result);
        }

        private static int vowelsCount(char[] charArray)
        {
            int result = 0;

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == 'a' || charArray[i] == 'e' || charArray[i] == 'i' ||
                    charArray[i] == 'o' || charArray[i] == 'u')
                {
                    result++;
                }
            }
            return result;
        }
    }
}
