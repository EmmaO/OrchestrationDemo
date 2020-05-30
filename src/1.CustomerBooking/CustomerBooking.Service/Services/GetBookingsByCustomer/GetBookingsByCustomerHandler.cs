using CustomerBooking.Data;
using Microsoft.EntityFrameworkCore;
using OrchestrationDemo.Handlers;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerBooking.Service.Services.GetBookingsByCustomer
{
    public class GetBookingsByCustomerHandler : IRequestHandler<GetBookingsByCustomerRequest, GetBookingsByCustomerResponse>
    {
        private readonly CustomerBookingContext _context;

        public GetBookingsByCustomerHandler(CustomerBookingContext context)
        {
            _context = context;
        }

        public async Task<HandlerResponse<GetBookingsByCustomerResponse>> HandleAsync(GetBookingsByCustomerRequest request)
        {
            var bookings = await _context
                .Booking
                .Where(x => x.CustomerId == request.CustomerId)
                .Select(x => new GetBookingsByCustomerResponse.Booking
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    PickupPostcode = x.PickupPostcode,
                    DestinationPostcode = x.DestinationPostcode,
                    JourneyCost = x.JourneyCost,
                    Status = x.Status.ToString()
                })
                .ToListAsync();

            return new OkHandlerResponse<GetBookingsByCustomerResponse>(new GetBookingsByCustomerResponse
            {
                Bookings = bookings
            });
        }
    }
}
