using System.Net;
using UrlShortener.Application.Wrappers.ServiceResponses;

namespace KamaCake.Application.Wrappers.ServiceResponses.ErrorResponses
{
    public class ErrorResponse : ServiceResponse
    {
        public ErrorResponse(bool IsSuccess, HttpStatusCode statusCode) : base(false, statusCode)
        {
        }

        public ErrorResponse(bool IsSuccess, HttpStatusCode statusCode, string message) : base(false, statusCode, message)
        {
        }
    }
}
