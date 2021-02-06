using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            //Path.Combine слага правилните символи на даден път /gosho/path.txt
            //в зависимост от операционната система на която работим
            var path = Path.Combine("data", "input.txt");
            var dest = Path.Combine("data", "output.txt");

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (TextReader text = new StreamReader(file))
                {
                    using (FileStream destFile = new FileStream(dest, FileMode.Create))
                    {
                        using (TextWriter newText = new StreamWriter(destFile))
                        {
                            string line = text.ReadLine();
                            int counter = 0;
                            while (line != null)
                            {

                                if (counter % 2 != 0)
                                {
                                    newText.WriteLine(line);

                                }
                                counter++;
                                line = text.ReadLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
