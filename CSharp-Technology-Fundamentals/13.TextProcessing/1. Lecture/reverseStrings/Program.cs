using System;
using System.Linq;

namespace reverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                var reversed = $"{string.Join("", command.Reverse())}";
                Console.WriteLine($"{command} = {reversed}");
            }
        }
    }
}
