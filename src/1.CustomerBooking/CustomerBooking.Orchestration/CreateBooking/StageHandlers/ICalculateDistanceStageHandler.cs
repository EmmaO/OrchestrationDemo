using CustomerBooking.Service.ExternalClients.CostCalculation.Requests;
using CustomerBooking.Service.ExternalClients.CostCalculation.Responses;
using Orchestration;
using System.Threading.Tasks;

namespace CustomerBooking.Orchestration.CreateBooking.StageHandlers
{
    public interface ICalculateDistanceStageHandler
    {
        Task<StageHandlerResponse<GetJourneyCostResponse>> CalculateDistance(GetJourneyCostRequest request);
    }
}