using System.Net;

namespace EventRegistration.Application.Wrappers.ServiceResponses
{
    public class ServiceResponseWithData<T> : ServiceResponse
    {
        public T Value { get; private set; }
        //Mesajsiz
        public ServiceResponseWithData(T value, bool isSuccess=true, HttpStatusCode statusCode = HttpStatusCode.OK) : base(isSuccess, statusCode)
        {
            Value = value;
        }

        //mesajli
        public ServiceResponseWithData(T value, bool isSuccess=true, HttpStatusCode statusCode = HttpStatusCode.OK, string message = "ugurlu") : base(isSuccess, statusCode, message)
        {
            Value = value;
        }
        public ServiceResponseWithData()
        {

        }
    }
}
