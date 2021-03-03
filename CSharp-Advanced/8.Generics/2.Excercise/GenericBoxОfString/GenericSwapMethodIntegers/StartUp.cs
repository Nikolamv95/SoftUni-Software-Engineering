using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            var currList = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                int input = int.Parse(Console.ReadLine());
                currList.Add(input);
            }

            int[] changeIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(currList, changeIndexes[0], changeIndexes[1]);

            foreach (var item in currList)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        public static void Swap<T>(List<T> currList, int index, int indexToChange)
        {
            var currValue = currList[index];
            var valueToChange = currList[indexToChange];
            currList[index] = valueToChange;
            currList[indexToChange] = currValue;
        }
    }
}
