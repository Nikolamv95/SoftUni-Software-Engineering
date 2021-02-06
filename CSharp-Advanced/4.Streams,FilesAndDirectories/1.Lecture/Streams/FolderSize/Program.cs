using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("E:\\TestFolder");
            double size = 0;

            foreach (var item in files)
            {
                var info = new FileInfo(item);
                size += info.Length;
            }

            var sumInMB = (size / 1024) / 1024;

            Console.WriteLine(sumInMB);
        }
    }
}
