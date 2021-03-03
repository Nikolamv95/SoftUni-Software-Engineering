using System;
using System.Linq;

namespace Threeuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Input 1
            string[] input = Console.ReadLine().Split().ToArray();
            string fullName = $"{input[0]} {input[1]}";
            string address = input[2];
            Tuple<string, string> tuple1 = new Tuple<string, string>(fullName, address);

            //Input 2
            string[] input2 = Console.ReadLine().Split().ToArray();
            var tuple2 = new Tuple<string, int>(input2[0], int.Parse(input2[1]));

            //Input 3
            string[] input3 = Console.ReadLine().Split().ToArray();
            int numer1 = int.Parse(input3[0]);
            double numer2 = double.Parse(input3[1]);
            var tuple3 = new Tuple<int, double>(numer1, numer2);

            Console.WriteLine(tuple1.ToString());
            Console.WriteLine(tuple2.ToString());
            Console.WriteLine(tuple3.ToString());
        }
    }
}
