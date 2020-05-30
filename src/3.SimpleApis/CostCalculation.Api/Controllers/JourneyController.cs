using System;
using Microsoft.AspNetCore.Mvc;

namespace CostCalculation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
       
        [HttpGet]
        [Route("cost/from/{pickupPostcode}/to/{destinationPostcode}")]
        public IActionResult GetJourneyCost(string pickupPostcode, string destinationPostcode)
        {
            //real application would call out to a service layer to calculate cost here
            var res = new
            {
                Cost = new Random().Next(0, 100)
            };

            return Ok(res);
        }
    }
}