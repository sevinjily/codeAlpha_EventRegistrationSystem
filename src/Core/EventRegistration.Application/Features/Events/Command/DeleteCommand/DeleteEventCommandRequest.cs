using EventRegistration.Application.Wrappers.ServiceResponses;
using MediatR;

namespace EventRegistration.Application.Features.Events.Command.DeleteCommand
{
    public class DeleteEventCommandRequest:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
