using System;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                var sideOrUser = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = sideOrUser[1];

                switch (command)
                {
                    case "|":
                        var dataSide = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                        break;
                    case "->":
                        var forceSide = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                        break;
                }

            }
        }
    }
}
