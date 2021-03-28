using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BattleCards.Data;
using BattleCards.ViewModels;
using Microsoft.EntityFrameworkCore;
using SUS.HTTP;
using SUS.MvcFramework;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private ApplicationDbContext dbContext;

        public CardsController()
        {
            this.dbContext = new ApplicationDbContext();
        }


        public HttpResponse Add()
        {

            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {

            if (this.Request.FormDate["name"].Length < 5)
            {
                return this.Error("Name should be at least 5 characters long.");
            }
            
            this.dbContext.Cards.Add(new Card()
            {
                Name = this.Request.FormDate["name"],
                ImageUrl = this.Request.FormDate["image"],
                Keyword = this.Request.FormDate["keyword"],
                Attack = int.Parse(this.Request.FormDate["attack"]),
                Health = int.Parse(this.Request.FormDate["health"]),
                Description = this.Request.FormDate["description"],
            });

            dbContext.SaveChanges();

            return this.Redirect("/");
        }

        public HttpResponse All()
        {
            var cardsViewModel = this.dbContext.Cards.Select(x => new CardViewModel()
            {
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword,
                Description = x.Description,
                Id = x.Id
            }).ToList();

            return this.View(cardsViewModel);
        }

        public HttpResponse Collection()
        {
            return this.View();
        }
    }
}
