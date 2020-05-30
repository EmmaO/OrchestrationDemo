using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OrchestrationDemo.Handlers
{
    public class OkHandlerResponse : HandlerResponse
    {
        public OkHandlerResponse(HttpStatusCode httpStatusCode)
        {
            this.StatusCode = httpStatusCode;
            this.Success = true;
        }

        public OkHandlerResponse()
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Success = true;
        }
    }

    public class OkHandlerResponse<T> : HandlerResponse<T>
    {
        public OkHandlerResponse(HttpStatusCode httpStatusCode, T response)
        {
            this.StatusCode = httpStatusCode;
            this.SuccessResponse = response;
            this.Success = true;
        }

        public OkHandlerResponse(T response)
        {
            this.StatusCode = HttpStatusCode.OK;
            this.SuccessResponse = response;
            this.Success = true;
        }
    }
}
