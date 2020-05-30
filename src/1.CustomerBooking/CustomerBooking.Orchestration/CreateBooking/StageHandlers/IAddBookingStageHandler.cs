using CustomerBooking.Service.Services.CreateBooking;
using Orchestration;
using System.Threading.Tasks;

namespace CustomerBooking.Orchestration.CreateBooking.StageHandlers
{
    public interface IAddBookingStageHandler
    {
        Task<StageHandlerResponse> AddBooking(CreateBookingRequest request);
    }
}