using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OrchestrationDemo.Handlers
{
    public class FailedHandlerResponse : HandlerResponse
    {
        public FailedHandlerResponse(HttpStatusCode httpStatusCode, ErrorResponse response)
        {
            this.StatusCode = httpStatusCode;
            this.ErrorResponse = response;
            this.Success = false;
        }
    }

    public class FailedHandlerResponse<T> : HandlerResponse<T>
    {
        public FailedHandlerResponse(HttpStatusCode httpStatusCode, ErrorResponse response)
        {
            this.StatusCode = httpStatusCode;
            this.ErrorResponse = response;
            this.Success = false;
        }
    }
}
