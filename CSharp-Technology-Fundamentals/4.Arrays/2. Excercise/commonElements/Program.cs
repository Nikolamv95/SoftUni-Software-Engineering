using System;
using System.Linq;

namespace commonElements
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] array1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] array2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string result = string.Empty;

            for (int i = 0; i < array2.Length; i++)
            {
                for (int j = 0; j < array1.Length; j++)
                {
                    string array1Name = array1[j];
                    string array2Name = array2[i];

                    if (array1Name == array2Name)
                    {
                        result += $"{array1[j]} ";
                        break;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }    
}
