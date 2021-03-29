using System;
using System.Collections.Generic;
using System.Text;
using BattleCards.Data;
using Microsoft.EntityFrameworkCore;
using BattleCards.Controllers;
using BattleCards.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace BattleCards
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            //This service register the Interface with it`s methods )IUsersService, and in addition register which
            //implementation of this interface we want to use. IUsersService could have multiple heirs (childs).
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardService, CardService>();
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
