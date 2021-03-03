using System;
using System.Linq;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Input 1
            string[] input = Console.ReadLine().Split().ToArray();
            string fullName = $"{input[0]} {input[1]}";
            string address = input[2];
            string addres = $"{input[3]} {input[4]}";
            Threeuple<string, string, string> tuple1 = new Threeuple<string, string, string>(fullName, address, addres);

            //Input 2
            string[] input2 = Console.ReadLine().Split().ToArray();
            string name = input2[0];
            int beers = int.Parse(input2[1]);
            string drunkOrNot = input2[2];
            var tuple2 = new Threeuple<string, int, string>(name, beers, drunkOrNot);

            //Input 3
            string[] input3 = Console.ReadLine().Split().ToArray();
            var tuple3 = new Threeuple<string, double, string>(input3[0], double.Parse(input3[1]), input3[2]);

            Console.WriteLine(tuple1.ToString());
            Console.WriteLine(tuple2.DrunkOrNot());
            Console.WriteLine(tuple3.ToString());
        }
    }
}
