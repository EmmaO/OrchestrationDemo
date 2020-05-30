using CustomerBooking.Service.ExternalClients.DriverApp.Requests;
using Orchestration;
using System.Threading.Tasks;

namespace CustomerBooking.Orchestration.CreateBooking.StageHandlers
{
    public interface IAddDriverJobStageHandler
    {
        Task<StageHandlerResponse> AddDriverJob(AddJobRequest request);
    }
}