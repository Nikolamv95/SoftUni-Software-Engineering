using System;

namespace LinkedList_Viktor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            for (int i = 0; i < 20; i++)
            {
                list.AddHead(new Node(i));
            }
            Console.WriteLine($"{list.Pop().Value}");
        }        
    }
}
