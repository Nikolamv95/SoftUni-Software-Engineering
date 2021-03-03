using System;
using System.Linq;

namespace ArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int result = SumNumbers(array, 0);
            Console.WriteLine(result);
        }

        private static int SumNumbers(int[] array, int startIndex)
        {
            //Създаваме дъно, кога рекурсията трябва да спре.
            //Спира когато indexa достигне дължината на масива
            if (startIndex == array.Length)
            {
                //връща резултат 0
                return 0;
            }

            //Този израз е: Дай ми сумата на стойността на първия индекс, със стойността на всички индекси до края
            int result1 = array[startIndex] + SumNumbers(array, startIndex + 1);
            return result1;
        }
    }
}
