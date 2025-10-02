using EventRegistration.Application.Bases;

namespace EventRegistration.Application.Features.Events.Exceptions
{
    public class EventTitleMustNotBeSameException:BaseException
    {
        public EventTitleMustNotBeSameException():base("Belə bir event artıq mövcuddur!"){}
       
    }
}
