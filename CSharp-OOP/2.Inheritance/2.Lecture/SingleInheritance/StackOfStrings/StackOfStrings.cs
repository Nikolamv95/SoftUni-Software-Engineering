using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }

            return false;
        }

        public void AddRange(Stack<string> newCollection)
        {
            int num = newCollection.Count;
            for (int i = 0; i < num; i++)
            {
                this.Push(newCollection.Pop());
            }
        }
    }
}
