using System;

namespace arrayRotationV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                                       .Split();

            int rotation = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotation; i++)
            {
                string numberToRotate = array[0];

                for (int j = 1; j < array.Length; j++)
                {
                    string currentNumber = array[j];
                    array[j - 1] = currentNumber;
                }
                array[array.Length - 1] = numberToRotate;
            }
            Console.WriteLine(string.Join(' ', array));
        }
    }
}
