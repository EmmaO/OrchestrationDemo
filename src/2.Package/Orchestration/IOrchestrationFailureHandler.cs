using OrchestrationDemo.Handlers;
using System;
using System.Threading.Tasks;

namespace Orchestration
{
    public interface IOrchestrationFailureHandler
    {
        Task<HandlerResponse> HandleOrchestrationFailure(Exception ex);
    }
}