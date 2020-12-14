using System;

namespace minNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int minValue = int.MaxValue;

            while (input != "Stop")
            {
                int number = Convert.ToInt32(input);

                if (minValue > number)
                {
                    minValue = number;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(minValue);
        }
    }
}
