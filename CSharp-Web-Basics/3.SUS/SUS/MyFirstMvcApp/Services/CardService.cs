using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleCards.Data;
using BattleCards.ViewModels.Cards;

namespace BattleCards.Services
{
    public class CardService : ICardService
    {
        private ApplicationDbContext db;

        public CardService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(AddCardInputModel input)
        {
            var card = new Card()
            {
                Name = input.Name,
                ImageUrl = input.ImageUrl,
                Keyword = input.Keyword,
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description,
            };

            this.db.Cards.Add(card);
            db.SaveChanges();

            return card.Id;
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            return this.db.Cards.Select(x => new CardViewModel()
            {
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword,
                Description = x.Description,
                Id = x.Id
            }).ToList();
        }

        public IEnumerable<CardViewModel> GetByUserId(string userId)
        {
            return this.db.UserCards
                .Where(x => x.UserId == userId)
                .Select(x => new CardViewModel()
                {
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                    Description = x.Card.Description,
                    ImageUrl = x.Card.ImageUrl,
                    Name = x.Card.Name,
                    Type = x.Card.Keyword,
                    Id = x.CardId
                })
                .ToList();
        }

        public void AddCardToUserCollection(string userId, int cardId)
        {
            if (this.db.UserCards.Any(x=> x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            this.db.UserCards.Add(new UserCard()
            {
                CardId = cardId,
                UserId = userId
            });

            this.db.SaveChanges();
        }

        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);

            if (userCard == null)
            {
                return;
            }

            this.db.UserCards.Remove(userCard);
            this.db.SaveChanges();
        }
    }
}
