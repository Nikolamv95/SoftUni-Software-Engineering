using System;
using System.Collections.Generic;

namespace YieldReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> array = GetEnumerator();//Този метод не се извиква и компилатора го пропуска. Ще се извика чак когато влезне във 
            //Foreach-a и започне да печата данните. var item in array -> in взима функцията на MoveNext() и влиза в метода долу, създава масива
            //влиза във фор цикъла и с Yeld return връща текущата стойност

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            //Всяко нещо е IEnumerable, като то има референция към GetEnumerator. При колекциите не самата колекция пази данните
            //а GetEnumerator се грижи за съхранението им, като той дава референция на колекцията да може да достъпи и отпечата данните си

            //Това е разбивка на ForEach-a
            var enumerator = array.GetEnumerator();
            while (enumerator.MoveNext())
            {
                //Виж тук
                Console.WriteLine(enumerator.Current);
            }

            foreach (var item in RandomEnumerator())
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<int> GetEnumerator()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };


            for (int i = 0; i < array.Length; i++)
            {
                //Този израз билдва отзад цял Enumerator и го връща на колекцията в Main метода, за да може самиата колекция да го използва
                //като foreach-ва. При обхождането на колекцията при всеки елемент ще се извиква този Yield return
                //Имаме ли веднъж yield return не можем да имаме нормален Return
                //Също така можем да имаме колкото си искаме yield return. Влизайки в първия Yield return то отива в (Погледни ConsoleWriteline)
                //отпечатва това което му е зададено и се връща
                yield return array[i];
                //за втория Yield return, Като отново отива в CW и се връща за 
                yield return array[i];
                //третия и т.н.
                yield return array[i];

                //НА Yield return можем да казваме да връща каквито си пожелаем данни в различни ситуации. Виж пример 1.1
            }

            //Можем да имаме Yield return тук, горе, където си пожелаем и да връща каквото му кажем
        }

        //Пример 1.1 - Използваме yield return спрямо нуждите които имаме
        private static IEnumerable<int> RandomEnumerator()
        {
            Random rand = new Random();
            while (true)
            {
                yield return rand.Next();
            }
        }
    }
}
