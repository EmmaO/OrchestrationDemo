using CustomerBooking.Orchestration.CreateBooking.StageHandlers;
using CustomerBooking.Service.ExternalClients.CostCalculation.Requests;
using CustomerBooking.Service.ExternalClients.DriverApp.Requests;
using CustomerBooking.Service.ExternalClients.Payment.Requests;
using CustomerBooking.Service.Services.CreateBooking;
using Orchestration;
using OrchestrationDemo.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBooking.Orchestration.CreateBooking
{
    public class CreateBookingOrchestrator : IRequestHandler<CreateBookingOrchestrationRequest>
    {
        private readonly ICalculateDistanceStageHandler _calculateDistanceStageHandler;
        private readonly IChargeCustomerStageHandler _chargeCustomerStageHandler;
        private readonly IAddBookingStageHandler _addBookingStageHandler;
        private readonly IAddDriverJobStageHandler _addDriverJobStageHandler;
        private readonly ICompensationContext _compensationContext;
        private readonly IOrchestrationFailureHandler _orchestrationFailureHandler;

        public CreateBookingOrchestrator(
            ICalculateDistanceStageHandler calculateDistanceStageHandler, 
            IChargeCustomerStageHandler chargeCustomerStageHandler,
            IAddBookingStageHandler addBookingStageHandler,
            IAddDriverJobStageHandler addDriverJobStageHandler,
            ICompensationContext compensationContext,
            IOrchestrationFailureHandler orchestrationFailureHandler
        )
        {
            _calculateDistanceStageHandler = calculateDistanceStageHandler;
            _chargeCustomerStageHandler = chargeCustomerStageHandler;
            _addBookingStageHandler = addBookingStageHandler;
            _addDriverJobStageHandler = addDriverJobStageHandler;
            _compensationContext = compensationContext;
            _orchestrationFailureHandler = orchestrationFailureHandler;
        }

        public async Task<HandlerResponse> HandleAsync(CreateBookingOrchestrationRequest request)
        {
            try
            {
                var journeyCostResult = await _calculateDistanceStageHandler.CalculateDistance(new GetJourneyCostRequest
                {
                    PickupPostcode = request.PickupPostcode,
                    DestinationPostcode = request.DestinationPostcode
                });
                _compensationContext.AddCompensationAction(journeyCostResult.CompensationTransaction);


                var chargeResult = await _chargeCustomerStageHandler.ChargeCustomer(new ChargeRequest
                {
                    Amount = journeyCostResult.Response.Cost,
                    CustomerId = request.CustomerId
                });
                _compensationContext.AddCompensationAction(chargeResult.CompensationTransaction);


                var addBookingResult = await _addBookingStageHandler.AddBooking(new CreateBookingRequest
                {
                    CustomerId = request.CustomerId,
                    PickupPostcode = request.PickupPostcode,
                    DestinationPostcode = request.DestinationPostcode,
                    JourneyCost = journeyCostResult.Response.Cost
                });
                _compensationContext.AddCompensationAction(addBookingResult.CompensationTransaction);


                var addDriverJobResult = await _addDriverJobStageHandler.AddDriverJob(new AddJobRequest
                {
                    PickupPostcode = request.PickupPostcode,
                    DestinationPostcode = request.DestinationPostcode
                });
                _compensationContext.AddCompensationAction(addDriverJobResult.CompensationTransaction);
            } catch (Exception ex)
            {
                return await _orchestrationFailureHandler.HandleOrchestrationFailure(ex);
            }

            return new OkHandlerResponse();
        }
    }
}
