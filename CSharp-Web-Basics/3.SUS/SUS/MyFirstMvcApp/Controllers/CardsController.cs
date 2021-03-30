using BattleCards.Data;
using BattleCards.ViewModels.Cards;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Linq;
using BattleCards.Services;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private ICardService cardService;

        public CardsController(ICardService cardService)
        {
            this.cardService = cardService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 5 || (model.Name.Length > 15))
            {
                return this.Error("Name should be between 5 and 15 characters long!");
            }

            if (string.IsNullOrWhiteSpace(model.ImageUrl))
            {
                return this.Error("The image is required!");
            }

            if (!Uri.TryCreate(model.ImageUrl, UriKind.Absolute, out _))
            {
                return this.Error("The image should start with https://site!");
            }

            if (String.IsNullOrWhiteSpace(model.Keyword))
            {
                return this.Error("Keyword is required!");
            }

            if (model.Attack < 0)
            {
                return this.Error("Attack should be non negative integer!");
            }

            if (model.Health < 0)
            {
                return this.Error("Health should be non negative integer!");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 200)
            {
                return this.Error("Description is required and it`s length should be at most to 200 characters!");
            }

            var cardId = this.cardService.AddCard(model);
            var userId = this.GetUserId();
            this.cardService.AddCardToUserCollection(userId, cardId);

            return this.Redirect("/cards/all");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }
            
            var cardsViewModel = this.cardService.GetAll();

            return this.View(cardsViewModel);
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            var userId = this.GetUserId();
            var cards = this.cardService.GetByUserId(userId);

            return this.View(cards);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            this.cardService.AddCardToUserCollection(userId, cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            this.cardService.RemoveCardFromUserCollection(userId, cardId);

            return this.Redirect("/Cards/Collection");
        }
    }
}
