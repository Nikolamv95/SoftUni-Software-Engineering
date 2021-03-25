using System.Collections.Generic;
using System.Diagnostics;
using SUS.HTTP;
using System.Threading.Tasks;
using MyFirstMvcApp.Controllers;
using SUS.MvcFramework;

namespace MyFirstMvcApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup());
        }
    }
}
