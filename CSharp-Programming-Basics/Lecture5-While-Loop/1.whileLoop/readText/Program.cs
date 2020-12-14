using System;
using System.Reflection.Metadata.Ecma335;

namespace readText
{
    class Program
    {
        static void Main(string[] args)
        {
            

            while (true)
            {
                string name = Console.ReadLine();

                if (name != "Stop")
                {
                    Console.WriteLine(name);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
