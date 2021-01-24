using System;

namespace substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string removeWord = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            int indexToDel = text.IndexOf(removeWord);

            while (indexToDel != -1)
            {
                text = text.Remove(indexToDel, removeWord.Length);
                indexToDel = text.IndexOf(removeWord);
            }

            Console.WriteLine(text);
        }
    }
}
