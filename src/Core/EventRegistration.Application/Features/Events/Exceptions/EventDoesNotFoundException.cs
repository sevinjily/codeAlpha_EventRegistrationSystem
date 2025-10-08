using EventRegistration.Application.Bases;

namespace EventRegistration.Application.Features.Events.Exceptions
{
    public class EventDoesNotFoundException : BaseException
    {
        public EventDoesNotFoundException() : base("event didn't find!") { }
    }
}
