using System;

namespace signOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dayOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday",
                                   "Friday", "Saturday", "Sunday"};

            int numberDay = int.Parse(Console.ReadLine());

            if (numberDay >= 1 && numberDay <= 7)
            {
                Console.WriteLine(string.Join(' ', dayOfWeek[numberDay - 1]));
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
            
        }
    }
}
