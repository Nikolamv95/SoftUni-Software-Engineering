using System;
using System.Collections.Generic;

namespace ImplementingStackAndQueues
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomList myCustomList = new CustomList();

            myCustomList.Add(43);
            myCustomList.Add(44);
            myCustomList.Add(45);
            myCustomList.Add(46);
            myCustomList.Add(47);
            myCustomList.Add(48);
            myCustomList.Add(49);
            myCustomList.Add(50);
            myCustomList.Insert(3, 100);

            bool isFound = myCustomList.Contains(100);
            myCustomList.Swap(1, 3);

            //int currValue = myCustomList[0];
            //int nextValue = myCustomList[1];
            //myCustomList[0] = nextValue;
            //myCustomList[1] = currValue;

            Action<int> action = x => x.ToString();

            myCustomList.ForEach(x => x.ToString());

            foreach (var item in myCustomList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
