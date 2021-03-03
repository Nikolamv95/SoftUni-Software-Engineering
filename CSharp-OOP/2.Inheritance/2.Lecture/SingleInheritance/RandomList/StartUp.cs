using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.Add("Petko");
            randomList.Add("Petko1");
            randomList.Add("Petko2");
            Console.WriteLine(randomList.RandomString());
        }
    }
}
