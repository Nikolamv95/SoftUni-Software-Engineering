using System;

namespace elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int elevateCapacity = int.Parse(Console.ReadLine());

            int sum = 0;

            sum = numberOfPeople / elevateCapacity;

            if (numberOfPeople % elevateCapacity != 0)
            {
                sum += 1;
            }

            Console.WriteLine(sum);
        }
    }
}
