using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Api.Requests
{
    public class ChargeRequest
    {
        public int CustomerId { get; set; }
        public double Amount { get; set; }
    }
}
