﻿using System;

namespace CustomerBooking.Service.Services.CreateBooking
{
    public class CreateBookingRequest
    {
        public int CustomerId { get; set; }
        public string PickupPostcode { get; set; }
        public string DestinationPostcode { get; set; }
        public double JourneyCost { get; set; }
    }
}