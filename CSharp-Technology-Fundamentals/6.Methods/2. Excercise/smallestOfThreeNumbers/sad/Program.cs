using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vowels_Sum
{
    class Vowels_Sum
    {
        static void Main()
        {
            int total = 0;

            string sentence = Console.ReadLine().ToLower();

            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == 'a' || sentence[i] == 'e')
                {
                    total++;
                }
            }
            Console.WriteLine("Your total number of vowels is: {0}", total);

            Console.ReadLine();
        }
    }
}