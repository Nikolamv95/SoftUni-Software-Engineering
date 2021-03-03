using System;

namespace ShadowingMembers_Classes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            TennisEvent tenis = new TennisEvent();
            tenis.Duration = DateTime.Now;
            tenis.PrintEvent();
            Console.WriteLine("Отпечатва и двата Start метода");
            tenis.Start();
            Console.WriteLine(tenis.ToString());
        }
    }
}
