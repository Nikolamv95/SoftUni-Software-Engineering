using System;

namespace BinarySearch
{
    //BinarySearch взима стойността средната стойност на елементите и проверява дали числото което търсим
    //е по-голямо от средната стойност или по-малко. 1, 2, 3, 4, 5 -> средна стойност 15 / 5 = 3. Ако ние търсим 2
    //то 2 е преди 3 следователно числата от 3 нагоре не се проверяват. След това се взима отново средната стойност на
    //1,2,3 = 6 / 3 = 2, разделяме остатъка от масива на 2 демек индекс 1 и виждаме индекс 1 равен ли е на средната стойност 
    //и тази която търсим ако не значи продължаваме докато не стигнем до стойността която търсим на точния индекс
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 5, 7, 8, 100, 430, 12 };
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(array, number, 0, array.Length));

        }

        private static int BinarySearch(int[] array, int number, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int middle = (start + end) / 2;

            if (number < array[middle])
            {
                return BinarySearch(array, number, start, middle - 1);
            }
            if (number > array[middle])
            {
                return BinarySearch(array, number, middle + 1, end);
            }
            else
            {
                return middle;
            }
        }
    }
}
