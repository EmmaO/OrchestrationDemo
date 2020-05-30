using CustomerBooking.Service.ExternalClients.DriverApp.Requests;
using CustomerBooking.Service.ExternalClients.DriverApp.Responses;
using OrchestrationDemo.Handlers;
using System.Threading.Tasks;

namespace CustomerBooking.Service.ExternalClients.DriverApp
{
    public interface IDriverAppClient
    {
        Task<HandlerResponse<AddJobResponse>> AddJob(AddJobRequest request);
        Task<HandlerResponse> CancelJob(CancelJobRequest request);
    }
}