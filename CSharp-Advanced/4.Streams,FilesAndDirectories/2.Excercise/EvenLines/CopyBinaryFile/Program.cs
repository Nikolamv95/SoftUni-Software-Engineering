using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Четем файла
            using FileStream readFileStream = new FileStream("copyMe.png", FileMode.Open);
            using FileStream writeFileStream = new FileStream("SoftUniLogo.png", FileMode.Create);

            //Пренасяме 
            byte[] buffer = new byte[4096];

            while (readFileStream.CanRead)
            {
                int counter = readFileStream.Read(buffer, 0, buffer.Length);

                if (counter == 0)
                {
                    break;
                }
                writeFileStream.Write(buffer);
            }
            
        }
    }
}
