using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverApp.Api.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string PickupPostcode { get; set; }
        public string DestinationPostcode { get; set; }
        public bool Cancelled { get; set; }
    }
}
