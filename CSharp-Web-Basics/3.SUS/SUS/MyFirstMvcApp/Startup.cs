using System;
using System.Collections.Generic;
using System.Text;
using BattleCards.Data;
using Microsoft.EntityFrameworkCore;
using BattleCards.Controllers;
using SUS.HTTP;
using SUS.MvcFramework;

namespace BattleCards
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
