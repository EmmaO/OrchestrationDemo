using CustomerBooking.Service.ExternalClients.DriverApp;
using CustomerBooking.Service.ExternalClients.DriverApp.Requests;
using Orchestration;
using RequestHandlers;
using System.Threading.Tasks;

namespace CustomerBooking.Orchestration.CreateBooking.StageHandlers
{
    public class AddDriverJobStageHandler : IAddDriverJobStageHandler
    {
        private readonly IDriverAppClient _driverAppClient;

        public AddDriverJobStageHandler(IDriverAppClient driverAppClient)
        {
            _driverAppClient = driverAppClient;
        }

        public async Task<StageHandlerResponse> AddDriverJob(AddJobRequest request)
        {
            var res = await _driverAppClient.AddJob(request);

            if (!res.StatusCode.IsSuccessStatusCode())
            {
                throw new OrchestrationException(res.StatusCode, res.ErrorResponse);
            }

            return new StageHandlerResponse(async () =>
            {
                var compensationRes = await _driverAppClient.CancelJob(new CancelJobRequest
                {
                    JobId = res.SuccessResponse.Id
                });

                if (!compensationRes.StatusCode.IsSuccessStatusCode())
                {
                    throw new OrchestrationException(res.StatusCode, res.ErrorResponse);
                }
            });
        }
    }
}
