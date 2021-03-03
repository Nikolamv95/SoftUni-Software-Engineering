using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList_Viktor
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public  bool IsReversed { get; set; }

        public void Reverse()
        {
            var oldHead = Head;
            Head = Tail;
            Tail = oldHead;
        }

        public int Count()
        {
            Node<T> currNode = Head;
            int counter = 0;

            while (currNode != null)
            {
                currNode = currNode.Next;
                counter++;
            }

            return counter;

        }

        public void ForEach(Action<Node<T>> action)
        {
            Node<T> currNode = Head;

            while (currNode != null)
            {
                action(currNode);
                currNode = currNode.Next;
            }
        }

        public Node<T>[] ToArray()
        {
            List<Node<T>> list = new List<Node<T>>();
            this.ForEach(node => list.Add(node));
            return list.ToArray();
        }

        public void AddHead(Node<T> newHead)
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

        public void AddLast(Node<T> newTail)
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

        public Node<T> RemoveFirst()
        {
            var head = Head;
            this.Head = this.Head.Next;
            return head;
        }

        public Node<T> RemoveLast()
        {
            var oldTail = this.Tail;
            Tail = this.Tail.Previous;
            return oldTail;
        }

        public void ReverseLinkdList()
        {
            Node<T> currNode = Tail;

            while (currNode != null)
            {
                Console.WriteLine(currNode.Value);
                currNode = currNode.Previous;
            }

        }

        public bool Remove(T value)
        {
            Node<T> currNode = Head;

            while (currNode != null)
            {
                if (currNode.Value.Equals(value))
                {
                    currNode.Previous.Next = currNode.Next;
                    currNode.Next.Previous = currNode.Previous;
                    return true;
                }
                else
                {
                    currNode = currNode.Next;
                }
            }

            return false;
        }

        public bool Contains(T value)
        {
            bool isFound = false;

            ForEach(node =>
            {
                if (node.Value.Equals(value))
                {
                    isFound = true;
                }
            });
            return isFound;
        }
    }
}
