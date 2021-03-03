using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public  bool IsReversed { get; set; }

        public void Reverse()
        {
            var oldHead = Head;
            Head = Tail;
            Tail = oldHead;
        }

        public int Count()
        {
            Node currNode = Head;
            int counter = 0;
            while (currNode != null)
            {
                currNode = currNode.Next;
                counter++;
            }

            return counter;

        }

        public void ForEach(Action<Node> action)
        {
            Node currNode = Head;

            while (currNode != null)
            {
                action(currNode);
                currNode = currNode.Next;
            }
        }

        public Node[] ToArray()
        {
            List<Node> list = new List<Node>();
            this.ForEach(node => list.Add(node));
            return list.ToArray();
        }

        public void AddHead(Node newHead)
        {
            if (Head == null)
            {
                Head = newHead;
                Tail = newHead;
            }
            else
            {
                newHead.Next = Head;
                Head.Previous = newHead;
                Head = newHead;
            }
        }

        public void AddLast(Node newTail)
        {
            if (Head == null)
            {
                Head = newTail;
                Tail = newTail;
            }
            else
            {
                newTail.Previous = Tail;
                Tail.Next = newTail;
                Tail = newTail;
            }
        }

        public void PrintList()
        {

            this.ForEach(node => Console.WriteLine(node.Value));
        }

        public Node RemoveFirst()
        {
            var head = Head;
            this.Head = this.Head.Next;
            return head;
        }

        public Node RemoveLast()
        {
            var oldTail = this.Tail;
            Tail = this.Tail.Previous;
            return oldTail;
        }

        public void ReverseLinkdList()
        {
            Node currNode = Tail;

            while (currNode != null)
            {
                Console.WriteLine(currNode.Value);
                currNode = currNode.Previous;
            }

        }
    }
}
