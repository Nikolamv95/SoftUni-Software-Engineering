using System;
using System.Collections.Generic;
using System.Text;
using BattleCards.ViewModels.Cards;

namespace BattleCards.Services
{
   public interface ICardService
   {
       int AddCard(AddCardInputModel input);
       IEnumerable<CardViewModel> GetAll();
       IEnumerable<CardViewModel> GetByUserId(string userId);
       void AddCardToUserCollection(string userId, int cardId);
       void RemoveCardFromUserCollection (string userId, int cardId);
   }
}
