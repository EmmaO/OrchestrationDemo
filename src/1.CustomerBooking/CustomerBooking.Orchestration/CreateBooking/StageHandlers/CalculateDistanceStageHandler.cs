using CustomerBooking.Service.ExternalClients.CostCalculation;
using CustomerBooking.Service.ExternalClients.CostCalculation.Requests;
using CustomerBooking.Service.ExternalClients.CostCalculation.Responses;
using Orchestration;
using RequestHandlers;
using System.Threading.Tasks;

namespace CustomerBooking.Orchestration.CreateBooking.StageHandlers
{
    public class CalculateDistanceStageHandler : ICalculateDistanceStageHandler
    {
        private readonly ICostCalculationClient _costCalculationClient;

        public CalculateDistanceStageHandler(ICostCalculationClient distanceCalculationClient)
        {
            _costCalculationClient = distanceCalculationClient;
        }

        public async Task<StageHandlerResponse<GetJourneyCostResponse>> CalculateDistance(GetJourneyCostRequest request)
        {
            var res = await _costCalculationClient.GetJourneyCost(request);

            if (!res.StatusCode.IsSuccessStatusCode())
            {
                throw new OrchestrationException(res.StatusCode, res.ErrorResponse);
            }

            return new StageHandlerResponse<GetJourneyCostResponse>(res.SuccessResponse, () => Task.CompletedTask);
        }
    }
}
