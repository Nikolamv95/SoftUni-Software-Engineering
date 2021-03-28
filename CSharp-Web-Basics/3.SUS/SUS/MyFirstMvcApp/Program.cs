using System.Collections.Generic;
using System.Diagnostics;
using SUS.HTTP;
using System.Threading.Tasks;
using BattleCards.Controllers;
using SUS.MvcFramework;

namespace BattleCards
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup());
        }
    }
}
