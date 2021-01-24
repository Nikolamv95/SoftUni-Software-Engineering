using System;
using System.Text;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var sequence = input.ToCharArray();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < sequence.Length; i++)
            {
                var value = sequence[i] + 3;
                char result = (char)value;
                sb.Append(result);
            }

            Console.WriteLine(sb);

        }
    }
}
