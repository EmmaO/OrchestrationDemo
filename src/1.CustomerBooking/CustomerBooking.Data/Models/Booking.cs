using CustomerBooking.Data.Enums;
using System;

namespace CustomerBooking.Data.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string PickupPostcode { get; set; }
        public string DestinationPostcode { get; set; }
        public double JourneyCost { get; set; }
        public BookingStatus Status { get; set; }
    }
}
