using System.Net;

namespace TheMealApp.Common
{
    public sealed class HttpProcessResponse<T>
    {
        public HttpStatusCode HttpStatus { get; set; }
        public T Data { get; set; }
        public HttpProcessResponse(T response)
        {
            Data = response;
            HttpStatus = HttpStatusCode.RequestTimeout;
        }
        public HttpProcessResponse(HttpStatusCode httpStatusCode, T response)
        {
            Data = response;
            HttpStatus = httpStatusCode;
        }
    }
}

