using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverApp.Api.Requests
{
    public class AddJobRequest
    {
        public string PickupPostcode { get; set; }
        public string DestinationPostcode { get; set; }
    }
}
