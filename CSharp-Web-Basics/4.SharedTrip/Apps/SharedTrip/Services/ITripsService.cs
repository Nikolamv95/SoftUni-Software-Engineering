using System;
using System.Collections.Generic;
using System.Text;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        public void Create(TripInputModel input);
        public TripViewModel GetTrip(string tripId);
        public ICollection<TripViewModel> GetAll();
        void AddUserToTrip(string userId, string tripId);
        public bool IsUserAlreadyJoined(string userId, string tripId);
        public bool IsFreeSpaceToTheTrip(string tripId);
    }
}
