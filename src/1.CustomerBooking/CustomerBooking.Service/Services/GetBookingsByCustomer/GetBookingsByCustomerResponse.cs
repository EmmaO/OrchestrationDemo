using System;
using System.Collections.Generic;

namespace CustomerBooking.Service.Services.GetBookingsByCustomer
{
    public class GetBookingsByCustomerResponse
    {
        public IList<Booking> Bookings {get;set;}
        
        public class Booking
        {
            public Guid Id { get; set; }
            public int CustomerId { get; set; }
            public string PickupPostcode { get; set; }
            public string DestinationPostcode { get; set; }
            public double JourneyCost { get; set; }
            public string Status { get; set; }
        }
    }
}