using EventRegistration.Application.Bases;
using EventRegistration.Application.Features.EventRegistrations.Exceptions;
using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Features.EventRegistrations.Rules
{
    public class RegistrationRules:BaseRules
    {
        public Task EventMustExist(Event eventt)
        {
            if (eventt == null || eventt.IsDeleted==true) throw new EventMustExistException();
            return Task.CompletedTask;
        }
        public Task UserMustRegisterOneTime(Registration existingRegistration)
        {
            if (existingRegistration != null) throw new UserMustRegisterOneTimeException();
            return Task.CompletedTask;                                                                                          
        }
        public Task UserAgeMustBeGreaterThan11(int age)
        {
            if (age <= 11) throw new UserAgeMustBeGreaterThan11Exception();
            return Task.CompletedTask;
        }
        public Task UserMustBeAuthenticated(string user)
        {
            if (user == null)
                throw new UserMustBeAuthenticatedException();
            return Task.CompletedTask;
        }
        public Task UserMustBeExist(User user)
        {
            if (user == null)
                throw new UserMustBeExistException();
            return Task.CompletedTask;
        }
    }
}
