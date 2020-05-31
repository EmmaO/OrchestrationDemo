using Microsoft.Extensions.Logging;
using OrchestrationDemo.Handlers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Orchestration
{
    public class OrchestrationFailureHandler : IOrchestrationFailureHandler
    {
        private readonly ICompensationContext _compensationContext;
        private readonly ILogger<OrchestrationFailureHandler> _logger;

        public OrchestrationFailureHandler(ICompensationContext compensationContext, ILogger<OrchestrationFailureHandler> logger)
        {
            _compensationContext = compensationContext;
            _logger = logger;
        }

        public async Task<HandlerResponse> HandleOrchestrationFailure(Exception ex)
        {
            if (ex is OrchestrationException)
            {
                return await HandleOrchestrationException((OrchestrationException)ex);
            }
            else
            {
                var errorMessage = "An unexpected error occurred";

                _logger.LogError(ex, errorMessage);
                return await HandleOrchestrationException(new OrchestrationException(HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    ErrorMessage = new List<string> { errorMessage }
                }));
            }
        }

        private async Task<HandlerResponse> HandleOrchestrationException(OrchestrationException ex)
        {
            try
            {
                await _compensationContext.Rollback();

                var res = new FailedHandlerResponse(ex.StatusCode, ex.ErrorResponse);
                res.ErrorResponse.ErrorMessage.Insert(0, "Operation failed - rollback successful");

                return res;
            }
            catch (Exception)
            {
                var res = new FailedHandlerResponse(HttpStatusCode.InternalServerError, ex.ErrorResponse);
                res.ErrorResponse.ErrorMessage.Add("Operation failed - rollback failed. Manual intervention may be required");

                return res;
            }
        }
    }
}
