using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payment.Api.Models;
using Payment.Api.Requests;

namespace Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private static List<Transaction> _data = new List<Transaction>();

        [HttpGet]
        [Route("transaction")]
        public IActionResult GetTransactions()
        {
            return Ok(_data);
        }

        [HttpPost]
        public IActionResult Charge(ChargeRequest request)
        {
            CallExternalPaymentService(request.CustomerId, request.Amount);

            _data.Add(new Transaction
            {
                CustomerId = request.CustomerId,
                Amount = request.Amount,
                TimeStampUtc = DateTime.UtcNow
            });

            return Ok();
        }

        private void CallExternalPaymentService(Guid customerId, double amount)
        {
            //Call out to external payment service in real application
        }
    }
}