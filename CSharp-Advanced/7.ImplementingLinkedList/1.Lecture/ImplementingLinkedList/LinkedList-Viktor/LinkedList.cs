using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList_Viktor
{
    class LinkedList
    {
        public Node Head { get; set; }

        public void AddHead(Node node)
        {
            node.Next = Head;
            Head = node;
        }

        public void PrintList()
        {
            Node currNode = Head;

            while (currNode != null)
            {
                Console.WriteLine(currNode.Value);
                currNode = currNode.Next;
            }
        }

        public Node Pop()
        {
            var head = Head;
            this.Head = this.Head.Next;
            return head;
        }

    }
}
