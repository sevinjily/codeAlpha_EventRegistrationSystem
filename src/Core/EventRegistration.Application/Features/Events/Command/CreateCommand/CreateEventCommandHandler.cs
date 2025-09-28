using EventRegistration.Application.Interfaces.AutoMapper;
using MediatR;

namespace EventRegistration.Application.Features.Events.Command.CreateCommand
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommandRequest>
    {
        private readonly IMapper mapper;

        public CreateEventCommandHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public Task Handle(CreateEventCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
