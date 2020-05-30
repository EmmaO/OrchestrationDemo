using System;
using System.Threading.Tasks;
using CustomerBooking.Service.Services.BookTaxi;
using CustomerBooking.Service.Services.CancelBooking;
using CustomerBooking.Service.Services.CreateBooking;
using CustomerBooking.Service.Services.GetBookingsByCustomer;
using Microsoft.AspNetCore.Mvc;
using OrchestrationDemo.Handlers;

namespace CustomerBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IRequestHandler<CreateBookingRequest, CreateBookingResponse> _createBookingHandler;
        private readonly IRequestHandler<CancelBookingRequest> _cancelBookingHandler;
        private readonly IRequestHandler<GetBookingsByCustomerRequest, GetBookingsByCustomerResponse> _getBookingByCustomerHandler;

        public BookingController(
            IRequestHandler<CreateBookingRequest, CreateBookingResponse> createBookingHandler,
            IRequestHandler<CancelBookingRequest> cancelBookingHandler,
            IRequestHandler<GetBookingsByCustomerRequest, GetBookingsByCustomerResponse> getBookingByCustomerHandler
        )
        {
            _createBookingHandler = createBookingHandler;
            _cancelBookingHandler = cancelBookingHandler;
            _getBookingByCustomerHandler = getBookingByCustomerHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking()
        {
            await _createBookingHandler.HandleAsync(new CreateBookingRequest
            {
                CustomerId = Guid.NewGuid(),
                PickupPostcode = "m",
                DestinationPostcode = "p",
                JourneyCost = 12
            });

            return Ok();
        }

        [HttpGet]
        [Route("{customerId}")]
        public async Task<IActionResult> GetBookingsByCustomer(Guid customerId)
        {
            var res = await _getBookingByCustomerHandler.HandleAsync(new GetBookingsByCustomerRequest
            {
                CustomerId = customerId
            });

            return StatusCode((int) res.StatusCode, res.Response);
        }
    }
}