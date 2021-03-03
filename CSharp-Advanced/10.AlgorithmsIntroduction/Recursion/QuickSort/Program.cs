using System;
using System.Collections.Generic;
using System.Linq;

//QUICKSORT СЛУЖИ ЗА СОРТИРАНЕТО НА ДАННИ ВЪВ ВЪЗХОДЯЩ ИЛИ НИЗХОДЯЩ РЕД. QUIKSORT Е ИЗКЛЮЧИТЕЛНО БЪРЗ.
//ЛОГИКАТА ПРИ НЕГО Е СЛЕДНАТА. ЗА ТЕКУЩОТО ОБЯСНЕНИЕ РАБОТИМ С ДАННИ INT. ТОЙ ВЗИМА ЕДНО РАНДОМ ЧИСЛО ОТ ЦЯЛАТА КОЛЕКЦИЯ
//С МЕТОДА RANDOM, СЛЕД ТОВА РАЗПРЕДЕЛЯ ДАННИТЕ ОТ ОРИГИНАЛНАТА КОЛЕКЦИЯ В 2 РАЗЛИЧНИ КОЛЕКЦИИ, КАТО АКО РАНДОМ ЧИСЛОТО
//КОЕТО Е ИЗБРАНО Е 7 В МАСИВ1 СЕ СЛАГАТ ВСИЧКИ ЧИСЛА КОИТО СА ПО-МАЛКИ ОТ 7 А В МАСИВ2 СЕ СЛАГАТ ВСИЧКИ ЧИСЛА КОИТО
//СА ПО-ГОЛЕМИ ОТ 7(РЕДА В КОЙТО СЕ СЛАГАТ НЯМА ЗНАЧЕНИЕ. СЛЕД ТОВА ЗА МАСИВ 1 СЕ ИЗВИКВА РЕКУРСИЯ НА СЪЩИЯ МЕТОД
//И СЕ ПОЛУЧАВАТ СЪЩИТЕ СТЪПКИ ДОКАТО МАСИВ1 НЕ СЕ ПОДРЕДИ 1,2,3,4,5,6,(ПРИМЕР). СЛЕД ПРИКЛЮЧВАНЕТО НА МАСИВ1 (var leftSorted = QuickSort(leftList),
//СЕ ПРЕМИНАВА КЪМ МАСИВ2 var rightSorted = QuickSort(rightList), И СЕ ИЗВЪРШВАТ СЪЩИТЕ ОПЕРАЦИИ. ДЪНОТО НА РЕКУРСИЯТА
//В КРАЯ СЛЕД ПРИКЛЮЧВАНЕТО НА РЕКУРСИЯТА МАСИВ1 СЕ ОБЕДИНЯВА С НОВ МАСИВ КОЙТО СЪДЪРЖА РАНДОМ ЧИСЛОТО, СЛЕД КАТО СЕ ОБЕДИНЯТ РЕЗУЛТАТА СЕ 
//ОБЕДИНЯВА С МАСИВ2 И КАТО РЕЗУЛТАТ СЕ ВРЪЩА СОРТИРАНАТА КОЛЕКЦИЯ. ПО-ДОБРЕ Е В QUICKSORT ДА СЕ РАБОТИ СЪС СПИСЪЦИ, ЗАЩОТО НЕ СЕ ИЗИСКВАТ
//СЛОЖНИ ОПЕРАЦИИ КАТО ПРИ МАСИВА.

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 5, 2, 9, 8, 3, 7 };
            //var sorted = QuickSort(array.ToList());
            var arrayList = array.ToList();
            QuickSortImproved(arrayList, 0, arrayList.Count - 1);
            Console.WriteLine(string.Join(' ', arrayList));
        }

        static Random rand = new Random();

        public static void QuickSortImproved(List<int> array, int left, int right)
        {
            if (left <  right)
            {
                var partitionIndex = Partition(array, left, right);
                QuickSortImproved(array, left, partitionIndex);
                QuickSortImproved(array, partitionIndex + 1, right);
            }
        }

        static int Partition(List<int> array, int left, int right)
        {
            int pivot = array[(left + right) / 2];
            int i = left - 1;
            int j = right + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (array[i] < pivot);
                do
                {
                    j--;

                } while (array[j] > pivot);

                if (i >= j)
                {
                    return j;
                }

                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;

            }

        }

        ////static List<int> QuickSort(List<int> array)
        //{
        //    if (array.Count <= 1)
        //    {
        //        return array;
        //    }

        //    int number = array[rand.Next(0, array.Count)];
        //    List<int> leftList = new List<int>();
        //    List<int> rightList = new List<int>();

        //    for (int i = 0; i < array.Count; i++)
        //    {
        //        if (array[i] < number)
        //        {
        //            leftList.Add(array[i]);
        //        }
        //        if (array[i] > number)
        //        {
        //            rightList.Add(array[i]);
        //        }
        //    }

        //    var leftSorted = QuickSort(leftList);
        //    var rightSorted = QuickSort(rightList);

        //    return leftSorted.Concat(new List<int>() { number }).Concat(rightSorted).ToList();
        //}
    }
}
