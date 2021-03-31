using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private ApplicationDbContext db;
        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(TripInputModel input)
        {
            try
            {
                var trip = new Trip()
                {
                    StartPoint = input.StartPoint,
                    EndPoint = input.EndPoint,
                    DepartureTime = input.DepartureTime,
                    Seats = input.Seats,
                    Description = input.Description,
                    ImagePath = input.ImagePath,
                };

                this.db.Trips.Add(trip);
                this.db.SaveChanges();
            }
            catch (ArgumentException ar)
            {
                throw ar;
            }
        }

        public TripViewModel GetTrip(string tripId)
        {
            return this.db.Trips
                .Where(x => x.Id == tripId)
                .Select(x => TripViewSelectData(x))
                .FirstOrDefault();
        }

        public ICollection<TripViewModel> GetAll()
        {
            return this.db.Trips
                .Select(x => TripViewSelectData(x))
                .ToList();
        }

        public void AddUserToTrip(string userId, string tripId)
        {
            var trip = GetCurrentTrip(tripId);
            trip.Seats -= 1;

            try
            {
                var userToTrip = new UserTrip()
                {
                    UserId = userId,
                    TripId = tripId,
                };

                this.db.UserTrips.Add(userToTrip);
                this.db.SaveChanges();
            }
            catch (ArgumentException ar)
            {
                throw ar;
            }
        }

        public bool IsUserAlreadyJoined(string userId, string tripId)
        {
            return this.db.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);
        }

        public bool IsFreeSpaceToTheTrip(string tripId)
        {
            var trip = GetCurrentTrip(tripId);

            if (trip.Seats >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Trip GetCurrentTrip(string tripId)
        {
            var trip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);
            return trip;
        }

        private static TripViewModel TripViewSelectData(Trip x)
        {
            return new TripViewModel()
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime,
                Seats = x.Seats,
                Description = x.Description,
                ImagePath = x.ImagePath,
            };
        }
    }
}
