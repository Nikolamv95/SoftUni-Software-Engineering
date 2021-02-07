using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string extension = "*.*";
            string path = "./";
            string[] fileNames = Directory.GetFiles(path, extension);
            Dictionary<string, Dictionary<string, double>> dicOfFiles = new Dictionary<string, Dictionary<string, double>>();

            foreach (var fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                string exten = fileInfo.Extension;
                string name = fileInfo.Name;
                double length = fileInfo.Length / 1024.0;

                Dictionary<string, double> currFile = new Dictionary<string, double>();

                if (dicOfFiles.ContainsKey(exten) == false)
                {
                    currFile.Add(name, length);
                    dicOfFiles.Add(exten, currFile);
                }
                else
                {
                    dicOfFiles[exten].Add(name, length);
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach ((string currExtension, Dictionary<string, double> currFile) in dicOfFiles
                                                                                            .OrderByDescending(x=>x.Value.Count)
                                                                                            .ThenBy(x=>x.Key))
            {
                sb.AppendLine(currExtension);
                foreach ((string name, double length) in currFile)
                {
                    sb.AppendLine($"--{name} - {length:f3}kb");
                }
            }

             string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dest = Path.Combine(desktopPath, "rep.txt");
            File.WriteAllText(dest, sb.ToString());
        }
    }
}
