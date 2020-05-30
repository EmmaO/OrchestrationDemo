using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBooking.Service.ExternalClients.DriverApp.Requests
{
    public class AddJobRequest
    {
        public string PickupPostcode { get; set; }
        public string DestinationPostcode { get; set; }
    }
}
