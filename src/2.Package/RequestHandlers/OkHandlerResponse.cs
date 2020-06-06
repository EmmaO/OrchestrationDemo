using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RequestHandlers
{
    public class OkHandlerResponse : HandlerResponse
    {
        public OkHandlerResponse(HttpStatusCode httpStatusCode)
        {
            StatusCode = httpStatusCode;
            Success = true;
        }

        public OkHandlerResponse()
        {
            StatusCode = HttpStatusCode.OK;
            Success = true;
        }
    }

    public class OkHandlerResponse<T> : HandlerResponse<T>
    {
        public OkHandlerResponse(HttpStatusCode httpStatusCode, T response)
        {
            StatusCode = httpStatusCode;
            SuccessResponse = response;
            Success = true;
        }

        public OkHandlerResponse(T response)
        {
            StatusCode = HttpStatusCode.OK;
            SuccessResponse = response;
            Success = true;
        }
    }
}
