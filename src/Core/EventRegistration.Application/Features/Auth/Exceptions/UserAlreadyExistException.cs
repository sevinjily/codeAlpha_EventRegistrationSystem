using EventRegistration.Application.Bases;

namespace EventRegistration.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException :BaseException
    {
        public UserAlreadyExistException():base("This user is already exist!")  { }
    }
}
