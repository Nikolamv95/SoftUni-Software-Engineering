using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Стъпка 1 - вкарваме Input
            double[] input = Console.ReadLine()
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Select(double.Parse)
                             .ToArray();

            //Стъпка 2 - създаваме списък
            SortedDictionary<double, int> numbers = new SortedDictionary<double, int>();

            //Стъпка 3 - прочитаме данните от input-a
            foreach (var number in input)
            {
                //Ако input-a не съществува в колекцията numbers, то влизаме в if-a
                //и го добавяме, като стойността му е 1, защото се среща за първи път
                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 1);
                }
                else
                { //Ако съществува input в колекцията влизаме в else-a достъпваме конкретния KEY
                  //и към него добавяме +1 защото го срещаме за втори път и т.н
                    numbers[number] += 1;
                }
            }

            //Стъпка 4 - прочитаме данните които са се запаметили в колекция numbers и ги печатаме
            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }

        }
    }
}
