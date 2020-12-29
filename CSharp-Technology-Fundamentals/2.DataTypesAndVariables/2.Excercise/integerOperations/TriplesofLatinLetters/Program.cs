using System;

namespace TriplesofLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                for (int j = 0; j < input; j++)
                {
                    for (int k = 0; k < input; k++)
                    {
                        //97 е малко "а" в ASCII таблицата
                        char firstChar = (char)(97 + i);
                        char secondChar = (char)(97 + j);
                        char thirthChar = (char)(97 + k);
                        Console.WriteLine($"{firstChar}{secondChar}{thirthChar}");
                    }
                }
            }
        }
    }
}
