using CustomerBooking.Service.ExternalClients.CostCalculation.Requests;
using CustomerBooking.Service.ExternalClients.CostCalculation.Responses;
using RequestHandlers;
using System.Threading.Tasks;

namespace CustomerBooking.Service.ExternalClients.CostCalculation
{
    public interface ICostCalculationClient
    {
        Task<HandlerResponse<GetJourneyCostResponse>> GetJourneyCost(GetJourneyCostRequest request);
    }
}