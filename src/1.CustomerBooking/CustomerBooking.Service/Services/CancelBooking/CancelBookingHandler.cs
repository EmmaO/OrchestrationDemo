using CustomerBooking.Data;
using CustomerBooking.Data.Enums;
using RequestHandlers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CustomerBooking.Service.Services.CancelBooking
{
    public class CancelBookingHandler : IRequestHandler<CancelBookingRequest>
    {
        private readonly CustomerBookingContext _context;

        public CancelBookingHandler(CustomerBookingContext context)
        {
            _context = context;
        }

        public async Task<HandlerResponse> HandleAsync(CancelBookingRequest request)
        {
            var booking = _context.Booking.FirstOrDefault(x => x.Id == request.BookingId);

            if (booking == null)
            {
                return new FailedHandlerResponse(
                    HttpStatusCode.NotFound,
                    new ErrorResponse
                    {
                        ErrorMessage = new List<string> { $"Booking with Id {request.BookingId} not found" }
                    }
                );
            }

            booking.Status = BookingStatus.Cancelled;
            await _context.SaveChangesAsync();

            return new OkHandlerResponse();
        }
    }
}
