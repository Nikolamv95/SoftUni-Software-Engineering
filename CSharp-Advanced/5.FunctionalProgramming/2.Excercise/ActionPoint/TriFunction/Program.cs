using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<string> listOfPeople = Console.ReadLine().Split().ToList();
            Func<string, int> getAsciiSum = p => p.Select(c =>(int)c).Sum();
            Func<List<string>, int, Func<string, int>, string> nameFunc = (listOfPeople, number, getAsciiSum)
                 => listOfPeople.FirstOrDefault(p => getAsciiSum(p) >= number);
            string result = nameFunc(listOfPeople, number, getAsciiSum);
            Console.WriteLine(result);


            string person = GetName(listOfPeople, number, getAsciiSum);
            Console.WriteLine(person);

        }

        static string GetName(List<string> people, int number, Func<string, int> func)
        {
            string res = null;

            foreach (var item in people)
            {
                if (func(item) >= number)
                {
                    res = item;
                    break;
                }
            }

            return res;
        }
    }
}
