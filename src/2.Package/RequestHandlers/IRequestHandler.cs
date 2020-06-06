using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RequestHandlers
{
    public interface IRequestHandler<TRequest>
    {
        Task<HandlerResponse> HandleAsync(TRequest request);
    }

    public interface IRequestHandler<TRequest, TResponse>
    {
        Task<HandlerResponse<TResponse>> HandleAsync(TRequest request);
    }
}
