using EventRegistration.Application.Bases;

namespace EventRegistration.Application.Features.EventRegistrations.Exceptions
{
    public class UserMustBeExistException:BaseException
    {
        public UserMustBeExistException():base("User not found!")
        {
            
        }
    }
}
