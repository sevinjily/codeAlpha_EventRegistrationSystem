using EventRegistration.Application.Bases;

namespace EventRegistration.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Email or Password is not correct!") { }
    
    }
}
