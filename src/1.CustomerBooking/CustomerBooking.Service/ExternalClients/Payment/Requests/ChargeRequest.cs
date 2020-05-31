using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBooking.Service.ExternalClients.Payment.Requests
{
    public class ChargeRequest
    {
        public int CustomerId { get; set; }
        public double Amount { get; set; }
    }
}
