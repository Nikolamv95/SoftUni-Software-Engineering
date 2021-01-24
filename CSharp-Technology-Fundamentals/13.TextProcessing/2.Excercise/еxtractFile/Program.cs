using System;

namespace еxtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int lastIndex = path.LastIndexOf("\\");
            path = path.Remove(0, lastIndex+1);
            var result = path.Split('.');
            Console.WriteLine($"File name: {result[0]}");
            Console.WriteLine($"File extension: {result[1]}");
        }
    }
}
