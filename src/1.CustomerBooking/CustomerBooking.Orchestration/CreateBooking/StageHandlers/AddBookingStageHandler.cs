using CustomerBooking.Service.Services.CancelBooking;
using CustomerBooking.Service.Services.CreateBooking;
using Orchestration;
using OrchestrationDemo.Handlers;
using RequestHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBooking.Orchestration.CreateBooking.StageHandlers
{
    public class AddBookingStageHandler : IAddBookingStageHandler
    {
        private readonly IRequestHandler<CreateBookingRequest, CreateBookingResponse> _createBookingHandler;
        private readonly IRequestHandler<CancelBookingRequest> _cancelBookingHandler;

        public AddBookingStageHandler(
            IRequestHandler<CreateBookingRequest, CreateBookingResponse> createBookingHandler,
            IRequestHandler<CancelBookingRequest> cancelBookingHandler
        )
        {
            _createBookingHandler = createBookingHandler;
            _cancelBookingHandler = cancelBookingHandler;
        }

        public async Task<StageHandlerResponse> AddBooking(CreateBookingRequest request)
        {
            var res = await _createBookingHandler.HandleAsync(request);

            if (!res.StatusCode.IsSuccessStatusCode())
            {
                throw new OrchestrationException(res.StatusCode, res.ErrorResponse);
            }

            return new StageHandlerResponse(async () =>
            {
                var compensationRes = await _cancelBookingHandler.HandleAsync(new CancelBookingRequest
                {
                    BookingId = res.SuccessResponse.CreatedResourceId
                });

                if (!compensationRes.StatusCode.IsSuccessStatusCode())
                {
                    throw new OrchestrationException(res.StatusCode, res.ErrorResponse);
                }
            });
        }
    }
}
