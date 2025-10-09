using EventRegistration.Application.Bases;

namespace EventRegistration.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException:BaseException
    {
        public EmailAddressShouldBeValidException() : base("Email Adress not found!") { }

    }
}
