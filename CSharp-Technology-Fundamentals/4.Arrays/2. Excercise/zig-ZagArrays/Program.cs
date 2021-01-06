using System;
using System.Linq;

namespace zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string[] arry1 = new string[lenght];
            string[] arry2 = new string[lenght];

            for (int i = 0; i < lenght; i++)
            {
                string [] currentArray = Console.ReadLine().Split(" ").ToArray();

                if (i % 2 == 0)
                {
                        arry1[i] = currentArray[0];
                        arry2[i] = currentArray[1];

                }
                else
                {
                        arry2[i] = currentArray[0];
                        arry1[i] = currentArray[1];
                }
            }
            Console.WriteLine(string.Join(' ', arry1));
            Console.WriteLine(string.Join(' ', arry2));
        }
    }
}
