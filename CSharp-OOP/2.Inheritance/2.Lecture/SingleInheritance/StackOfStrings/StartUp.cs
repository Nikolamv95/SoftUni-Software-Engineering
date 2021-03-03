using System;
using System.Collections.Generic;

namespace CustomStack
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> newCollection = new Stack<string>();
            newCollection.Push("joro");
            newCollection.Push("joro1");
            newCollection.Push("joro2");
            newCollection.Push("joro3");
            newCollection.Push("joro4");
            newCollection.Push("joro5");

            StackOfStrings currStack = new StackOfStrings();
            currStack.Push("Bai KOlio");
            currStack.Push("Bai KOlio1");
            currStack.Push("Bai KOlio2");
            currStack.Push("Bai KOlio3");

            currStack.AddRange(newCollection);
        }
    }
}
