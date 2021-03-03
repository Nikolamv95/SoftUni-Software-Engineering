using System;

namespace LinkedList_Viktor
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();


            for (int i = 0; i < 5; i++)
            {
                list.AddHead(new Node<string>("TOP5"));
            }

            Console.WriteLine(list.Count());

            for (int i = 0; i < 5; i++)
            {
                list.AddLast(new Node<string>("TOP"));
            }

            Console.WriteLine(list.Count());
            
            list.PrintList();

            list.Remove("TOP5");



            //for (int i = 0; i < 4; i++)
            //{
            //    list.AddHead(new Node(i));
            //}

            //Console.WriteLine($"{list.Tail.Value}");
            //Console.WriteLine($"{list.Tail.Previous.Value}");
            //Console.WriteLine($"{list.Tail.Previous.Previous.Value}");
            //Console.WriteLine($"{list.Tail.Previous.Previous.Previous.Value}");
            //Console.WriteLine($"{list.Head.Value}");

            Console.WriteLine($"{list.RemoveLast().Value}");
        }        
    }
}
