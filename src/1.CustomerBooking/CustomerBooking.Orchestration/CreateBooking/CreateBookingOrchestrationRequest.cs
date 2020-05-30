using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBooking.Orchestration.CreateBooking
{
    public class CreateBookingOrchestrationRequest
    {
        public string PickupPostcode { get; set; }
        public string DestinationPostcode { get; set; }
        public Guid CustomerId { get; set; }
    }
}
