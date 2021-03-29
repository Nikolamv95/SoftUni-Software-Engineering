using System;
using System.Collections.Generic;
using System.Text;
using BattleCards.Data;

namespace BattleCards.Services
{
    public class CardService : ICardService
    {
        private ApplicationDbContext db;

        public CardService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCard()
        {
            throw new NotImplementedException();
        }
    }
}
