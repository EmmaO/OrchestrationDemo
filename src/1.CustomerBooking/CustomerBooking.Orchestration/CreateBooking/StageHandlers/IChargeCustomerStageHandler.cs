using CustomerBooking.Service.ExternalClients.Payment.Requests;
using Orchestration;
using System.Threading.Tasks;

namespace CustomerBooking.Orchestration.CreateBooking.StageHandlers
{
    public interface IChargeCustomerStageHandler
    {
        Task<StageHandlerResponse> ChargeCustomer(ChargeRequest request);
    }
}