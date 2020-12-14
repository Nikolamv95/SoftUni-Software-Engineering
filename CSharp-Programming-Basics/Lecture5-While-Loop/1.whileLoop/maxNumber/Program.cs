using System;

namespace maxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxValue = int.MinValue;

            while (input != "Stop")
            {
                int number = Convert.ToInt32(input);

                if (maxValue < number)
                {
                    maxValue = number;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(maxValue);
        }
    }
}
