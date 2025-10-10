using EventRegistration.Application.Bases;

namespace EventRegistration.Application.Features.EventRegistrations.Exceptions
{
    public class UserMustBeAuthenticatedException:BaseException
    {
        public UserMustBeAuthenticatedException():base("User must be authenticated")
        {
            
        }

    }
}
