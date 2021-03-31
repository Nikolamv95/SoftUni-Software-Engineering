using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SharedTrip.Commons;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        //All trips
        public HttpResponse All()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            var tripViewModel = this.tripsService.GetAll();
            return this.View(tripViewModel);
        }

        //Add trip
        public HttpResponse Add()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripInputModel input)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            if (string.IsNullOrWhiteSpace(input.StartPoint))
            {
                return this.Error("Starting point could not be empty!");
            }

            if (string.IsNullOrWhiteSpace(input.EndPoint))
            {
                return this.Error("End point could not be empty!");
            }

            if (input.DepartureTime < DateTime.UtcNow)
            {
                return this.Error("Departure time cannot be same as current time!");
            }

            if (input.ImagePath != null)
            {
                if (string.IsNullOrWhiteSpace(input.ImagePath))
                {
                    return this.Error("Invalid url!");
                }
            }

            if (input.Seats < GlobalConstants.SeatsMinValue || input.Seats > GlobalConstants.SeatsMaxValue)
            {
                return this.Error("The seats should be between 2 and 6!");
            }

            if (input.Description.Length > GlobalConstants.DescriptionMaxLength || string.IsNullOrWhiteSpace(input.Description))
            {
                return this.Error("Description is required. Maximum allowed characters are 80!");
            }

            this.tripsService.Create(input);
            return this.Redirect("all");
        }

        //Show details
        public HttpResponse Details(string tripId)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            var viewModel = this.tripsService.GetTrip(tripId);
            return this.View(viewModel);
        }

        //Add user to the trip
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            var userId = this.GetUserId();

            if (!this.tripsService.IsFreeSpaceToTheTrip(tripId))
            {
               return this.Error("There is not enough seats for the trip!");
            }

            if (this.tripsService.IsUserAlreadyJoined(userId, tripId))
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            this.tripsService.AddUserToTrip(userId, tripId);

            return this.Redirect("All");
        }
    }
}
