using System;

namespace lowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result;
            char ch1 = char.Parse(Console.ReadLine());
            result = Char.IsUpper(ch1);

            if (result)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
