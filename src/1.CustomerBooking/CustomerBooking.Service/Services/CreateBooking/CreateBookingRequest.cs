using System;

namespace CustomerBooking.Service.Services.BookTaxi
{
    public class CreateBookingRequest
    {
        public Guid CustomerId { get; set; }
        public string PickupPostcode { get; set; }
        public string DestinationPostcode { get; set; }
        public double JourneyCost { get; set; }
    }
}