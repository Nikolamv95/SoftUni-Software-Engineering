using System;

namespace SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double maxSpace = double.Parse(Console.ReadLine());
            string input = string.Empty;
            int numOfCases = 0;            
            bool isFull = false;

            while ((input = Console.ReadLine()) != "End")
            {
                double spaceToFill = double.Parse(input);

                numOfCases += 1;

                if (maxSpace >= spaceToFill)
                {
                    if (numOfCases % 3 == 0)
                    {
                        maxSpace -= (spaceToFill * 0.1) + spaceToFill;

                        if (maxSpace < 0)
                        {
                            Console.WriteLine("No more space!");
                            isFull = true;
                            numOfCases -= 1;
                            break;
                        }
                    }
                    else
                    {
                        maxSpace -= spaceToFill;
                    }

                }
                else
                {
                    Console.WriteLine("No more space!");
                    isFull = true;
                    numOfCases -= 1;
                    break;
                }

            }

            if (isFull == false)
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }

            Console.WriteLine($"Statistic: {numOfCases} suitcases loaded.");
        }
    }
}
