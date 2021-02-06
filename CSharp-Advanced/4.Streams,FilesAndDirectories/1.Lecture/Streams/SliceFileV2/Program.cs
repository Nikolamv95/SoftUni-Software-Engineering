using System;
using System.IO;

namespace SliceFileV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "input.txt");
            string dest1 = Path.Combine("data", "output1.txt");
            string dest2 = Path.Combine("data", "output2.txt");
            string dest3 = Path.Combine("data", "output3.txt");
            string dest4 = Path.Combine("data", "output4.txt");

            var lines = File.ReadAllLines(path);
            string[] output = new string[lines.Length];
            int num = output.Length / 4;

            string[] output1 = new string[num];
            string[] output2 = new string[num];
            string[] output3 = new string[num];
            string[] output4 = new string[num];

            
            for (int i = 0; i < num - 1; i++)
            {
                output1[i] = lines[i];
            }
            File.WriteAllLines(dest1, output1);

            int counter = 0;
            for (int i = num - 1; i < num * 2 - 1; i++)
            {
                output2[counter] = lines[i];
                counter++;
            }
            File.WriteAllLines(dest2, output2);

            counter = 0;
            for (int i = num * 2 - 1; i < num * 3 - 1; i++)
            {
                output3[counter] = lines[i];
                counter++;
            }
            File.WriteAllLines(dest3, output3);

            counter = 0;
            for (int i = num * 3 - 1; i < num * 4 - 1; i++)
            {
                output4[counter] = lines[i];
                counter++;
            }
            File.WriteAllLines(dest4, output4);

        }
    }
}
