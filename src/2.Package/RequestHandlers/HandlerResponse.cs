using System;
using System.Net;

namespace RequestHandlers
{
    public class HandlerResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public ErrorResponse ErrorResponse { get; set; }
        public bool Success { get; set; }
        public virtual object Response => Success ? null : ErrorResponse;
    }

    public class HandlerResponse<T> : HandlerResponse
    {
        public T SuccessResponse { get; set; }
        public override object Response => Success ? SuccessResponse : (object)ErrorResponse;
    }
}
