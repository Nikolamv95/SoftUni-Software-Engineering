using System;
using System.Collections.Generic;
using System.Linq;

namespace readingListsFromTheConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вариант 1
            int length = int.Parse(Console.ReadLine());
            List<int> numbers = new List <int> ();
            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers.Add(number);
            }

            //Вариант 2
            string values = Console.ReadLine();
            List<string> items = values.Split(' ').ToList();
            List<int> nums = new List<int>();

            for (int i = 0; i < items.Count; i++)
            {
                nums.Add(int.Parse(items[i]));
            }

            //Или
            List <int> numbers2 = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToList();

            //Печатане на List
            for (int index = 0; index < numbers2.Count; index++)
            {
                Console.WriteLine(numbers2[index]);
            }

            //или
            Console.WriteLine(string.Join(" ", numbers2));
                                 

        }
    }
}
