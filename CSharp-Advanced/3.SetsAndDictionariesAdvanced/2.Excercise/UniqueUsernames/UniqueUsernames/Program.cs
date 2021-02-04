using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> setUsername = new HashSet<string>();
            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                string username = Console.ReadLine();
                setUsername.Add(username);
            }

            Console.WriteLine(string.Join(Environment.NewLine, setUsername));
        }
    }
}
