using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RequestHandlers
{
    public static class StatusCodeExtensions
    {
        public static bool IsSuccessStatusCode(this HttpStatusCode code)
        {
            return (int) code >= 200 && (int) code < 300;
        }
    }
}
