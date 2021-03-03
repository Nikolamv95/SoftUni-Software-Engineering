using System;
using System.Collections.Generic;
using System.Linq;

//MERGESORT е ДРУГ АЛГОРИТЪМ ЗА СОРТИРАНЕ НА ДАННИ В КОЛЕКЦИЯ. ТОЗИ МЕТОД РАЗДЕЛЯ ОСНОВНАТА КОЛЕКЦИЯ НА 2 РАВНИ ЧАСТИ 1, 5, 2, 9, 8, 3, 7.
//ЧАСТ 1 -> 1,5,2 / ЧАСТ 2 -> 9,8,3,7. ПЪРВОНАЧАЛНО РАБОТИ С ДАННИТЕ 1,5,2, СЛЕД ТОВА С 9,8,3,7. СЛЕД ТОВА ИЗВЪРШВА СЪЩИЯ ПРОЦЕС ЗА 1,5,2 КАТО
//РАЗДЕЛЯ НОВИ СПИСЪК НА МАЛКИ ЧАСТИЦИ, ДОКАТО НЕ ОСТАНАТ САМО 5 И 2 И НЕ ГИ КОМБИНИРА В НОВ ЛИСТ CombineArrays, КАТО ВЕЧЕ ПРОВЕРЯВА
//КОЯ СТОЙНОСТ Е ПО-ГОЛЯМА И Я ЗАПИСВА В ПРАВИЛНИЯ РЕД 2,5. СЛЕД КАТО ПРИКЛЮЧИ С 2 И 5 СЕ ВРЪЩА В MERGESORT МЕТОДА И ВЗИМА ОСТАНАЛТА ЧАСТ
//1 И НОВИЯ СПИСЪК 2,5. ОТНОВО ГИ ОБЕДИНЯВА В CombineArrays като резултата е 1,2,5. СЛЕД ПРИКЛЮЧВАНЕ НА ТАЗИ ОПЕРАЦИЯ ПРЕМИНАВА КЪМ
//9,8,3,7 КАТО ВЗИМА ПЪРВИЯ ПЪТ 9,8, СЛЕД ТОВА 3,7 ПРОМЕНЯ ПОЗИЦИИТЕ ИМ НА 8,9 И 3,7 И НАКРАЯ ГИ ОБЕДИНЯВА В ОБЩ СПИСЪК 3,7,8,9.
//СЛЕД ПРИКЛЮЧВАНЕ НА ТАЗИ ОПЕРАЦИЯ ИМА 2 НОВИ СПИСЪКА 1,2,5 И 3,7,8,9, КАТО ФИНАЛНО СЕ ВЛИЗА В COMBINEARRAYS И СЕ ВРЪЩА НОВ СПИСЪК 1,2,3,5,7,8,9.
namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 5, 2, 9, 8, 3, 7 };
            var sorted = MergeSort(array.ToList());
            Console.WriteLine(string.Join(' ', sorted));
        }

        private static List<int> MergeSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int middle = list.Count / 2;
            List<int> leftList = MergeSort(list.GetRange(0, middle));
            List<int> rightList = MergeSort(list.GetRange(middle, list.Count - middle));
            return CombineArrays(leftList, rightList);
        }

        private static List<int> CombineArrays(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            for (int i = leftIndex; i < left.Count; i++)
            {
                result.Add(left[i]);
            }

            for (int i = rightIndex; i < right.Count; i++)
            {
                result.Add(right[i]);
            }

            return result;
        }
    }
}
