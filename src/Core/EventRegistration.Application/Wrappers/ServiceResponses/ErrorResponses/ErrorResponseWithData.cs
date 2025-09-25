using System.Net;
using UrlShortener.Application.Wrappers.ServiceResponses;

namespace KamaCake.Application.Wrappers.ServiceResponses.ErrorResponses
{
    public class ErrorResponseWithData<T> : ServiceResponseWithData<T>
    {
        public ErrorResponseWithData(T value, bool isSuccess, HttpStatusCode statusCode) : base(value, false, statusCode)
        {
        }

        public ErrorResponseWithData(T value, bool isSuccess, HttpStatusCode statusCode, string message) : base(value, false, statusCode, message)
        {
        }
        public ErrorResponseWithData(bool isSuccess, HttpStatusCode statusCode, string message) : base(default, false, statusCode, message)
        {
        }
        public ErrorResponseWithData(bool isSuccess, HttpStatusCode statusCode) : base(default, false, statusCode)
        {
        }
    }
}
