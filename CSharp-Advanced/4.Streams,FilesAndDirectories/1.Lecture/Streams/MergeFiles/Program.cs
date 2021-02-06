using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            var pathOne = Path.Combine("data", "FileOne.txt");
            var pathTwo = Path.Combine("data", "FileTwo.txt");
            var dest = Path.Combine("data", "output.txt");

            using (var reader = new StreamReader(pathOne))
            {
                string currNum = string.Empty;

                while ((currNum = reader.ReadLine()) != null)
                {
                    int num = int.Parse(currNum);
                    numbers.Add(num);
                }
            }
            using (var reader = new StreamReader(pathTwo))
            {
                string currNum = string.Empty;

                while ((currNum = reader.ReadLine()) != null)
                {
                    int num = int.Parse(currNum);
                    numbers.Add(num);
                }
            }

            string[] output = new string[numbers.Count];
            numbers.Sort();
            for (int i = 0; i < numbers.Count; i++)
            {
                output[i] = numbers[i].ToString();
            }

            File.WriteAllLines(dest, output);
        }
    }
}
