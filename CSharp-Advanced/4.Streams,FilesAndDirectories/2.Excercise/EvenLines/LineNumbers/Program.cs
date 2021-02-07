using System;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "text.txt";
            string resultName = "output.txt";

            var lines = File.ReadAllLines(fileName);
            string[] output = new string[lines.Length];

            int counter = 1;

            foreach (var item in lines)
            {
                int letters = 0;
                int other = 0;

                foreach (Char c in item)
                {
                    if (char.IsLetter(c))
                    {
                        letters++;
                    }
                    if (char.IsPunctuation(c))
                    {
                        other++;
                    }                   
                }
                output[counter - 1] = $"Line{counter}: {item} ({letters})({other})";
                counter++;
            }
            File.WriteAllLines(resultName, output);
        }
    }
}
