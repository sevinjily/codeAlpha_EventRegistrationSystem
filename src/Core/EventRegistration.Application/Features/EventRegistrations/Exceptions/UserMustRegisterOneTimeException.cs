using EventRegistration.Application.Bases;

namespace EventRegistration.Application.Features.EventRegistrations.Exceptions
{
    public class UserMustRegisterOneTimeException:BaseException
    {
        public UserMustRegisterOneTimeException() : base("User must register one time!") { }

    }
}
