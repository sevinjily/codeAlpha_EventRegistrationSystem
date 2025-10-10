using EventRegistration.Application.Bases;

namespace EventRegistration.Application.Features.EventRegistrations.Exceptions
{
    public class UserAgeMustBeGreaterThan11Exception:BaseException
    {
        public UserAgeMustBeGreaterThan11Exception():base("User's age must be greater than 11!")
        {
            
        }
    }
}
