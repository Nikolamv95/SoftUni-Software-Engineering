﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ImplementingLinkedList
{
    /// <summary>
    /// Linked list of integers
    /// </summary>
    public class LinkedLIst : IEnumerable<int>
    {
        /// <summary>
        /// First node of the list
        /// </summary>
        public ListNode First { get; set; }
        /// <summary>
        /// Last node of the list
        /// </summary>
        public ListNode Last { get; set; }
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
        public LinkedLIst(IEnumerable<int> collection) : this()
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
        public void AddLast(int value)
        {
            var newElement = new ListNode(value);

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
        public void AddFirst(int value)
        {
            var newElement = new ListNode(value);

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

        public void AddAfter(ListNode node, int value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node can`t be null");
            }

            var newElement = new ListNode(value);
            newElement.Next = node.Next;
            node.Next = newElement;
            Count++;
        }

        public void AddBefore(ListNode node, int value)
        {
            if(node == null)
            {
                throw new ArgumentNullException("Node can`t be null");
            }

            var newElement = new ListNode(value);

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
        public IEnumerator<int> GetEnumerator()
        {
            ListNode currNode = First;

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
        public bool Contains(int value)
        {
            bool result = false;
            var currNode = First;

            while (currNode != null)
            {
                if (currNode.Value == value)
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
        public ListNode Find(int value)
        {
            ListNode result = null;

            var currNode = First;
            while (currNode != null)
            {
                if (currNode.Value == value)
                {
                    result = currNode;
                    break;
                }
                
                currNode = currNode.Next;

            }


            return result;
        }

        public void Remove(ListNode node)
        {
            if (node == null)
            {
                throw new 
            }
        }
    }
}
