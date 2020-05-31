using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Api.Models
{
    public class Transaction
    {
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public DateTime TimeStampUtc { get; set; }
    }
}
