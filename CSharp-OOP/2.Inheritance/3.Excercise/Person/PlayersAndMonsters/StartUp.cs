using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoulMaster soulMaster = new SoulMaster("PEsho", 19);
            Console.WriteLine(soulMaster.ToString()); 
        }
    }
}
