using EventRegistration.Application.Bases;
using EventRegistration.Application.Features.Auth.Exceptions;
using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Features.Auth.Rules
{
    public class AuthRules:BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
    }
}
