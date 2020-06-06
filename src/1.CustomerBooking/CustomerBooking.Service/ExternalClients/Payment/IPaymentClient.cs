using CustomerBooking.Service.ExternalClients.Payment.Requests;
using RequestHandlers;
using System.Threading.Tasks;

namespace CustomerBooking.Service.ExternalClients.Payment
{
    public interface IPaymentClient
    {
        Task<HandlerResponse> ChargeCustomer(ChargeRequest request);
    }
}