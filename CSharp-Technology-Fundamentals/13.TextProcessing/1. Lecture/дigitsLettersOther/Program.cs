using System;
using System.Text;

namespace digitsLettersOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();

            StringBuilder integers = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder charrs = new StringBuilder();

            for (int i = 0; i < chars.Length; i++)
            {
                char ch = chars[i];

                if (Char.IsDigit(ch) == true)
                {
                    integers.Append(ch);
                }
                else if (Char.IsLetter(ch) == true)
                {
                    letters.Append(ch);
                }
                else
                {
                    charrs.Append(ch);
                } 
            }
            Console.WriteLine($"{integers}\n{letters}\n{charrs}");
        }
    }
}
