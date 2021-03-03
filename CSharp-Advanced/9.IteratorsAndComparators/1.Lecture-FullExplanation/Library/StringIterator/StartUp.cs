using System;
using System.Collections.Generic;

namespace StringIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Инстанцираме си класа new StringLIstIEnumerable() и четем дефоултните стойности които
            //сме задали предварително в колекцията
            foreach (var item in new StringLIstIEnumerable())
            {
                Console.WriteLine(item);
            }

            string[] array = new string[] { "todor", "will make it", "you are the best" };
            StringLIstIEnumerable currValue = new StringLIstIEnumerable(array);

            foreach (var item in EndlessCollectionYield(currValue))
            {
                Console.WriteLine($"This is the message: {item}");
            }

        }

        public static IEnumerable<string> EndlessCollectionYield(StringLIstIEnumerable currValue)
        {

            IEnumerator<string> enumerator = currValue.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }

        }
    }
}
