using EventRegistration.Application.Wrappers.ServiceResponses;
using MediatR;

namespace EventRegistration.Application.Features.Events.Command.DeleteCommand
{
    public class DeleteCommandRequest:IRequest<ServiceResponse>
    {
        public Guid Id { get; set; }
    }
}
