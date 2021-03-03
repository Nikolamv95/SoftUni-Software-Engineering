using System;
using System.Collections.Generic;

namespace ImplementingLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var myList = new LinkedLIst<int>(new int[] { 3,4,5,6,7,8});
            var node = myList.Find(5);
            myList.AddAfter(node, 10);
            myList.AddLast(70);

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine(myList.Contains(7));

            List<int> newList = new List<int>();


            

            
        }
    }
}
