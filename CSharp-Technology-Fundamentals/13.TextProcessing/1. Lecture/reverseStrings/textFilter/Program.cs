using System;

namespace textFilter
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] wordsToBan = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();          

            for (int i = 0; i < wordsToBan.Length; i++)
            {
                string bannWord = wordsToBan[i];
                //Създаваме стринг като в скобите задаваме с какво да се заменят символите в стринг и колко пъти.
                string asterix = new string('*', bannWord.Length);

                text = text.Replace(bannWord, asterix);
            }

            Console.WriteLine(text);
        }
    }
}
