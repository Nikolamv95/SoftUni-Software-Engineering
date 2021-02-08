using System;
using System.Linq;

namespace EvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            numbers = numbers.Where(x => x % 2 == 0).OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join(", ", numbers));
            //или ние си създаваме функцията
            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsEvenNumber(numbers[i]))
                {
                    Console.Write($"{numbers[i]}, ");
                }
            }
            //или ние си вкарваме нашата функция в where
            numbers = numbers.Where(IsEvenNumber).OrderBy(x => x).ToArray();
            //можем да създадем и метод
            numbers = numbers.Where(x =>
            {
                Console.WriteLine($"X : {x}");
                return x % 2 == 0;
            }            
            ).OrderBy(x => x).ToArray();

        }

        static bool IsEvenNumber(int number)
        {
            return number % 2 == 0;
        }
    }
}
