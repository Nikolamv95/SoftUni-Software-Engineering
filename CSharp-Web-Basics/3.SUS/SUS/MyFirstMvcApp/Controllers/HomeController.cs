﻿using SUS.HTTP;
using SUS.MvcFramework;

namespace BattleCards.Controllers
{
    public class HomeController : Controller
    {
        //If we want we can invoke HttpRequest with this.Request and access the properties inside
        //this.Request.Body;

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("Cards/All");
            }
            else
            {
                return this.View();
            }
        }
    }
}
