using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerBooking.Api.Requests
{
    public class CreateBookingApiRequest
    {
        public string PickupPostcode { get; set; }
        public string DestinationPostcode { get; set; }
        public int CustomerId { get; set; }
    }
}
