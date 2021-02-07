using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            //Зипваме цялата папка
            //string path = "./";
            //string dest = "./../myzip.zip";
            //ZipFile.CreateFromDirectory(path, dest);

            string filePath = "../../../words.txt";
            using ZipArchive zipArchive = ZipFile.Open("../../../arhiv.zip", ZipArchiveMode.Create);
            zipArchive.CreateEntryFromFile(filePath, "newName.txt");
        }
    }
}
