using System;

namespace replaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int counter = 1;
            bool isEntered = false;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i+1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        counter += 1;
                        isEntered = true;
                    }
                    else
                    {
                        break;
                    }
                }

                if (isEntered == true)
                {
                    input = input.Remove(i, counter - 1);
                    counter = 1;
                    isEntered = false;
                }
                
            }

            Console.WriteLine(input);
        }
    }
}
