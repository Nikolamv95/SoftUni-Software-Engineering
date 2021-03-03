using System;
using System.Collections.Generic;

namespace IteratorSample
{
    class StartUp
    {
        static void Main(string[] args)
        {

            //Вариант 1 - създадохме безкрйна колекция която връща рандом числа
            //за да се случи това трябваше да създадем EndlessIterator ->
            foreach (var item in new EndlessCollection())
            {               //in отива в метода MoveNext() който от своя страна преминава към ново число и го връща
                Console.WriteLine(item);
            }

            //Вариант 2 - целият този запис във вариант 1 можем да го пропуснем ако направим един метод EndlessCollectionYield()
            //в който инстанцираме Random създадем безкраен While Цикъл и с yield return rand.Next() ще връщаме постоянно нови 
            //стойности на произволен принцип
            foreach (var item in EndlessCollectionYield())
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<int> EndlessCollectionYield()
        {
            Random rand = new Random();
            while (true)
            {
                yield return rand.Next();
            }
        }
    }
}
