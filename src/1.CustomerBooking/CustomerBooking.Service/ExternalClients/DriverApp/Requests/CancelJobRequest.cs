using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBooking.Service.ExternalClients.DriverApp.Requests
{
    public class CancelJobRequest
    {
        public Guid JobId { get; set; }
    }
}
