using EventRegistration.Application.Bases;
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
            IList<Event> events = await unitOfWork.GetReadRepository<Event>().GetAllAsync();

            await eventRules.EventTitleMustNotBeSame(events, request.EventName);

            Event eventt = new(request.EventName, request.Description, request.StartDate, request.EndDate, request.Location, request.UserLimit);

            await unitOfWork.GetWriteRepository<Event>().AddAsync(eventt);
            await unitOfWork.SaveAsync();
            //return new ServiceResponse(true,System.Net.HttpStatusCode.Created,"Ugurla yaradildi!");

            return Unit.Value;
        }
    }
}
