using System.Net;

namespace EventRegistration.Application.Wrappers.ServiceResponses
{
    public class ServiceResponse
    {
        public bool isSuccess { get; private set; }    // əməliyyat uğurlu olub-olmadığını göstərir
        public string Message { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        //MESAJSIZ
        public ServiceResponse(bool IsSuccess=true, HttpStatusCode statusCode=HttpStatusCode.OK)
        {
            isSuccess = IsSuccess;
            StatusCode = statusCode;
        }
      
        //MESAJLI
        public ServiceResponse(bool IsSuccess=true, HttpStatusCode statusCode = HttpStatusCode.OK, string message="ugurlu") : this(IsSuccess, statusCode)
        {
            {

                Message = message;
            }

        }
        public ServiceResponse()
        {

        }
    }
}
