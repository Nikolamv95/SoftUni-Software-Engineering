using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] separator = { ">>>" };
                string[] operations = command
                                      .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();

                switch (operations[0])
                {
                    case "Contains":
                        string substring = operations[1];
                        if (inputString.Contains(substring) == true)
                        {
                            Console.WriteLine($"{inputString} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string uppOrLoww = operations[1];
                        int startIndex = int.Parse(operations[2]);
                        int endIndex = int.Parse(operations[3]);

                        if (uppOrLoww == "Upper")
                        {
                            string sequence = inputString.Substring(startIndex, endIndex - startIndex);
                            string toUpperString = sequence.ToUpper();
                            inputString = inputString.Replace(sequence, toUpperString);
                            Console.WriteLine(inputString);
                        }
                        else if (uppOrLoww == "Lower")
                        {
                            string sequence = inputString.Substring(startIndex, endIndex - startIndex);
                            string toLowerString = sequence.ToLower();
                            inputString = inputString.Replace(sequence, toLowerString);
                            Console.WriteLine(inputString);
                        }
                        break;
                    case "Slice":
                        int startIndexSlice = int.Parse(operations[1]);
                        int endIndexSlice = int.Parse(operations[2]);
                        inputString = inputString.Remove(startIndexSlice, endIndexSlice - startIndexSlice);
                        Console.WriteLine(inputString);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {inputString}");
        }
    }
}
