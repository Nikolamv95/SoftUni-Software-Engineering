using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int compareNum = int.Parse(Console.ReadLine());

            List<string> result = new List<string>();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == compareNum)
                    {
                        string firstNum = numbers[i].ToString();
                        string secondNum = numbers[j].ToString();
                        string finalResult = firstNum + " " + secondNum;
                        result.Add(finalResult);
                    }
                } 
            }
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
