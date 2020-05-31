using System;
using System.Threading.Tasks;
using CustomerBooking.Api.Requests;
using CustomerBooking.Orchestration.CreateBooking;
using CustomerBooking.Service.Services.CancelBooking;
using CustomerBooking.Service.Services.GetBookingsByCustomer;
using Microsoft.AspNetCore.Mvc;
using OrchestrationDemo.Handlers;

namespace CustomerBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IRequestHandler<CreateBookingOrchestrationRequest> _createBookingOrchestrator;
        private readonly IRequestHandler<GetBookingsByCustomerRequest, GetBookingsByCustomerResponse> _getBookingByCustomerHandler;

        public BookingController(
            IRequestHandler<CreateBookingOrchestrationRequest> createBookingOrchestrator,
            IRequestHandler<GetBookingsByCustomerRequest, GetBookingsByCustomerResponse> getBookingByCustomerHandler
        )
        {
            _createBookingOrchestrator = createBookingOrchestrator;
            _getBookingByCustomerHandler = getBookingByCustomerHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingApiRequest request)
        {
            var res = await _createBookingOrchestrator.HandleAsync(new CreateBookingOrchestrationRequest
            {
                CustomerId = request.CustomerId,
                DestinationPostcode = request.DestinationPostcode,
                PickupPostcode = request.PickupPostcode
            });

            return StatusCode((int)res.StatusCode, res.Response);
        }

        [HttpGet]
        [Route("{customerId}")]
        public async Task<IActionResult> GetBookingsByCustomer(int customerId)
        {
            var res = await _getBookingByCustomerHandler.HandleAsync(new GetBookingsByCustomerRequest
            {
                CustomerId = customerId
            });

            return StatusCode((int) res.StatusCode, res.Response);
        }
    }
}