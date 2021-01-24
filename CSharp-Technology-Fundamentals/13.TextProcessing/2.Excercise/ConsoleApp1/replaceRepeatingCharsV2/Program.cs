using System;
using System.Text;

namespace replaceRepeatingCharsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            var input = Console.ReadLine().ToCharArray();

            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i] != input[i+1])
                {
                    sb.Append(input[i]);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
