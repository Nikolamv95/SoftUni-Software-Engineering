using System;
using System.IO;
using System.Linq;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "text.txt";
            string resultName = "output.txt";

            using StreamReader stremReader = new StreamReader(fileName);
            using StreamWriter streamWriter = new StreamWriter(resultName);

            var currLine = stremReader.ReadLine();
            int counter = 0;

            while (currLine != null)
            {
                if (counter % 2 == 0)
                {
                    string[] lineArray = currLine.Split(new string[] { "-", ",", ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
                    string result = string.Join("@", lineArray.Reverse());
                    streamWriter.WriteLine(result);
                }
                counter++;
                currLine = stremReader.ReadLine();
            }
        }
    }
}
