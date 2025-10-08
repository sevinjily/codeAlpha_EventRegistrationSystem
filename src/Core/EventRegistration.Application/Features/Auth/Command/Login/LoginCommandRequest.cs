using MediatR;
using System.ComponentModel;

namespace EventRegistration.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest:IRequest<LoginCommandResponse>
    {
        [DefaultValue("akbar@gmail.com")]
        public string Email { get; set; }

        [DefaultValue("Akbar1234_")]

        public string Password { get; set; }

    }
}
