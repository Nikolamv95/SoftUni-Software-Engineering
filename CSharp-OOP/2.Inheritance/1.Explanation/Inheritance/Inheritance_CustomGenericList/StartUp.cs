using System;

namespace Inheritance_CustomGenericList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //SoftUniList наследява нашия GenericList и всичките му методи и пропъртита
            SoftUniList<int> softUniList = new SoftUniList<int>();
            softUniList.Add(42);
            softUniList.Add(43);
            softUniList.Add(44);

            Console.WriteLine(string.Join(' ', softUniList));
        }
    }
}
