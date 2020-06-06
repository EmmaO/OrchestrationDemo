using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RequestHandlers
{
    public class FailedHandlerResponse : HandlerResponse
    {
        public FailedHandlerResponse(HttpStatusCode httpStatusCode, ErrorResponse response)
        {
            StatusCode = httpStatusCode;
            ErrorResponse = response;
            Success = false;
        }
    }

    public class FailedHandlerResponse<T> : HandlerResponse<T>
    {
        public FailedHandlerResponse(HttpStatusCode httpStatusCode, ErrorResponse response)
        {
            StatusCode = httpStatusCode;
            ErrorResponse = response;
            Success = false;
        }
    }
}
