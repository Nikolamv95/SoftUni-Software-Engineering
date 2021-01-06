using System;
using System.Collections.Generic;

namespace encryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberNames = int.Parse(Console.ReadLine());
            int counter = 0;

            List<int> list = new List<int>();


            while (numberNames > counter)
            {
                string name = Console.ReadLine();
                char[] charArray = name.ToCharArray();
                int finalResult = 0;

                for (int i = 0; i < charArray.Length; i++)
                {
                    if (charArray[i] == 'a' || charArray[i] == 'e' 
                        || charArray[i] == 'i' || charArray[i] == 'o'
                        || charArray[i] == 'u')
                    {
                        int number = charArray[i];
                        int result = number * charArray.Length;
                        finalResult += result;
                    }
                    else if (charArray[i] == 'A' || charArray[i] == 'E'
                        || charArray[i] == 'I' || charArray[i] == 'O'
                        || charArray[i] == 'U')
                         {
                            int number = charArray[i];
                            int result = number * charArray.Length;
                            finalResult += result;
                          }
                    else
                    {
                        int number = charArray[i];
                        int result = number / charArray.Length;
                        finalResult += result;
                    }
                }

                list.Add(finalResult);
                finalResult = 0;
                counter++;
            }

            list.Sort();
            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}
