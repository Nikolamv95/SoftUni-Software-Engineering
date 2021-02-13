using System;

namespace ActionPointV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namesInput = Console.ReadLine().Split(' ');
            Action<string[]> printData = a => Console.WriteLine(string.Join(Environment.NewLine, a));
            printData(namesInput);
        }
    }
}
