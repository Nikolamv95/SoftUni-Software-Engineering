using System;
using System.Linq;

namespace reverseArrayofStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                             .ToArray();

            //Вариант 1
            //Array.Reverse(array);
            //foreach (string item in array)
            //{
            //    Console.Write($"{item} ");
            //}

            //Вариант 2
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write($"{array[i]} ");
            }

            //Вариант 3
            Console.WriteLine(string.Join(' ',array.Reverse()));

            //string.Join извършва същата функция като Select, разделя символите един от друг.
            //string.Join(' ', array.Reverse())); това е синтаксиса ако искаме да ни обърне string-a
        }
    }
}
