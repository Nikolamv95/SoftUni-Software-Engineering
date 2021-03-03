using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ImplementingLinkedList
{
    /// <summary>
    /// Generic Linked list of integers
    /// </summary>
    public class LinkedLIst<T> : IEnumerable<T>
    {
        /// <summary>
        /// First node of the list
        /// </summary>
        public ListNode<T> First { get; set; }
        /// <summary>
        /// Last node of the list
        /// </summary>
        public ListNode<T> Last { get; set; }
        /// <summary>
        /// Number of nodes in the list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Create empty linked list
        /// </summary>
        public LinkedLIst()
        {
            this.Count = 0;
        }

        /// <summary>
        /// Create linked list from collection
        /// </summary>
        /// <param name="collection">Collection of integers to add to the list</param>
        public LinkedLIst(IEnumerable<T> collection) : this()
        {
            foreach (var value in collection)
            {
                this.AddLast(value);
            }
        }

        /// <summary>
        /// Adds new node to the end of the list
        /// </summary>
        /// <param name="value">Value to add</param>
        public void AddLast(T value)
        {
            var newElement = new ListNode<T>(value);

            if (Last == null)//Проверяваме дали нашия списък е празен, което означава че вкарваме първия елемент
            {
                First = newElement;
                Last = newElement;
            }
            else
            {
                //Записваме новия елемент на последно място
                Last.Next = newElement;
                //Тъй като вече има нов елемент на последно място предходния става предпоследен,
                //реално Last вече е предпоследния елемент и му подаваме стойността към която
                //трябва да сочи (тя е последния елемент)
                Last = newElement;
            }

            Count++;
        }

        /// <summary>
        /// Add new element on first place
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            var newElement = new ListNode<T>(value);

            if (Last == null)//Проверяваме дали нашия списък е празен, което означава че вкарваме първия елемент
            {
                First = newElement;
                Last = newElement;
            }
            else
            {
                newElement.Next = First;
                First = newElement;
            }

            Count++;
        }

        public void AddAfter(ListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node can`t be null");
            }

            var newElement = new ListNode<T>(value);
            newElement.Next = node.Next;
            node.Next = newElement;
            Count++;
        }

        public void AddBefore(ListNode<T> node, T value)
        {
            if(node == null)
            {
                throw new ArgumentNullException("Node can`t be null");
            }

            var newElement = new ListNode<T>(value);

            if (node == First)
            {
                newElement.Next = First;
                First = newElement;
            }
            else
            {
                var currElement = First;
                while (currElement != null)
                {
                    if (currElement.Next == node)
                    {
                        newElement.Next = node;
                        currElement.Next = newElement;
                        break;
                    }
                    currElement = currElement.Next;
                }
            }
            Count++;
        }

        /// <summary>
        /// Gets Enumerator for Linked List
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currNode = First;

            while (currNode != null)
            {
                yield return currNode.Value;
                currNode = currNode.Next;
            }
        }

        /// <summary>
        /// Gets Enumerator for Linked List
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Checks if value is in the list
        /// </summary>
        /// <param name="value">Value to search for</param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            bool result = false;
            var currNode = First;

            while (currNode != null)
            {
                if (currNode.Value.Equals(value))
                {
                    result = true;
                    break;
                }
                currNode = currNode.Next;
            }

            return result;
        }
        /// <summary>
        /// Find first node
        /// </summary>
        /// <param name="value">Searched node</param>
        /// <returns></returns>
        public ListNode<T> Find(T value)
        {
            ListNode<T> result = null;

            var currNode = First;
            while (currNode != null)
            {
                if (currNode.Value.Equals(value))
                {
                    result = currNode;
                    break;
                }
                
                currNode = currNode.Next;

            }


            return result;
        }

        public void Remove(ListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
