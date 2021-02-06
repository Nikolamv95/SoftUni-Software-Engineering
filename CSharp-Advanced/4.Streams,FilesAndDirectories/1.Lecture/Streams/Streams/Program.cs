using System;
using System.IO; 

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            //Path.Combine слага правилните символи на даден път /gosho/path.txt
            //в зависимост от операционната система на която работим
            var path = Path.Combine("gosho", "pesho.txt");
            Console.WriteLine(path);
        }
    }
}
