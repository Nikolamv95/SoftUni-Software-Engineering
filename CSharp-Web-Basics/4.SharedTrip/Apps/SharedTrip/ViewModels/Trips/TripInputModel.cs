using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class TripInputModel
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public ushort Seats { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
