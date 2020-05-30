using OrchestrationDemo.Handlers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Orchestration
{
    public class OrchestrationException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public ErrorResponse ErrorResponse { get; set; }

        public OrchestrationException(HttpStatusCode statusCode, ErrorResponse errorResponse)
        {
            StatusCode = statusCode;
            ErrorResponse = errorResponse;
        }
    }
}
