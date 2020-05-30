using CustomerBooking.Data;
using CustomerBooking.Data.Enums;
using CustomerBooking.Data.Models;
using OrchestrationDemo.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CustomerBooking.Service.Services.CreateBooking
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingRequest, CreateBookingResponse>
    {
        private readonly CustomerBookingContext _context;

        public CreateBookingHandler(CustomerBookingContext context)
        {
            _context = context;
        }

        public async Task<HandlerResponse<CreateBookingResponse>> HandleAsync(CreateBookingRequest request)
        {
            if (_context.Booking.Any(x => x.CustomerId == request.CustomerId && x.Status == BookingStatus.InProgress))
            {
                return new FailedHandlerResponse<CreateBookingResponse>(
                    HttpStatusCode.Conflict,
                    new ErrorResponse
                    {
                        ErrorMessage = new List<string> { "Cannot book new job while one is already in progress" }
                    }
                );
            }

            var newBooking = new Booking
            {
                PickupPostcode = request.PickupPostcode,
                DestinationPostcode = request.DestinationPostcode,
                JourneyCost = request.JourneyCost,
                CustomerId = request.CustomerId,
                Status = BookingStatus.InProgress
            };

            _context.Booking.Add(newBooking);
            await _context.SaveChangesAsync();

            return new OkHandlerResponse<CreateBookingResponse>(new CreateBookingResponse
            {
                CreatedResourceId = newBooking.Id
            });
        }
    }
}
