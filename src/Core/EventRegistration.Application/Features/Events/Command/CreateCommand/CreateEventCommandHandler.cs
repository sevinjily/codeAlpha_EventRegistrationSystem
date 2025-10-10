using EventRegistration.Application.Bases;
using EventRegistration.Application.Features.Events.Command.UpdateCommand;
using EventRegistration.Application.Features.Events.Rules;
using EventRegistration.Application.Interfaces.AutoMapper;
using EventRegistration.Application.Interfaces.UnitOfWorks;
using EventRegistration.Application.Wrappers.ServiceResponses;
using EventRegistration.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EventRegistration.Application.Features.Events.Command.CreateCommand
{
    public class CreateEventCommandHandler : BaseHandler,IRequestHandler<CreateEventCommandRequest,Unit>
    {
        private readonly EventRules eventRules;

        public CreateEventCommandHandler(EventRules eventRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
           
            this.eventRules = eventRules;
           
        }

        public IMapper Mapper { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        public async Task<Unit> Handle(CreateEventCommandRequest request, CancellationToken cancellationToken)
        {
                      
            Event eventt = mapper.Map<Event, CreateEventCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Event>().AddAsync(eventt);
           
            await unitOfWork.SaveAsync(); 

            return Unit.Value;
        }
    }
}
