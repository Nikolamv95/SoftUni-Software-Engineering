using System;
using System.Text;

namespace repeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string old = Console.ReadLine();
            int rotation = int.Parse(Console.ReadLine());

            string result = Formating(old, rotation);
            Console.WriteLine(result);
        }
        static string Formating(string old, int rotation)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < rotation; i++)
            {
                result.Append(old);
            }
            return result.ToString();
        }
    }
}
