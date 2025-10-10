using MediatR;

namespace EventRegistration.Application.Features.EventRegistrations.Command
{
    public class CreateEventRegistrationCommandRequest:IRequest<Unit>
    {
        public Guid EventId { get; set; }
    }
}
