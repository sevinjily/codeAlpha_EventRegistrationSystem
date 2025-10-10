using EventRegistration.Application.Bases;

namespace EventRegistration.Application.Features.EventRegistrations.Exceptions
{
    public class EventMustExistException:BaseException
    {
        public EventMustExistException() : base("This event Id doesn't find!") { }
    }
}
