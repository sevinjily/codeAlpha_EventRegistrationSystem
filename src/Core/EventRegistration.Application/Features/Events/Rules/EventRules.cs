using EventRegistration.Application.Bases;
using EventRegistration.Application.Features.Events.Exceptions;
using EventRegistration.Domain.Entities;

namespace EventRegistration.Application.Features.Events.Rules
{
    public class EventRules:BaseRules
    {
        public Task EventTitleMustNotBeSame(IList<Event> events,string requestEventName)
        {
            if(events.Any(x=>x.EventName==requestEventName)) throw new EventTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
    