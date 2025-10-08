using EventRegistration.Application.Features.Events.Rules;
using EventRegistration.Application.Interfaces.UnitOfWorks;
using EventRegistration.Application.Wrappers.ServiceResponses;
using EventRegistration.Domain.Entities;
using MediatR;

namespace EventRegistration.Application.Features.Events.Query
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQueryRequest, IList<GetAllEventsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EventRules eventRules;

        public GetAllEventsQueryHandler(IUnitOfWork unitOfWork,EventRules eventRules)
        {
            this.unitOfWork = unitOfWork;
            this.eventRules = eventRules;
        }
        public async Task<IList<GetAllEventsQueryResponse>> Handle(GetAllEventsQueryRequest request, CancellationToken cancellationToken)
        {
            var events = await unitOfWork.GetReadRepository<Event>().GetAllAsync();

           await eventRules.EventDoesNotFound(events);

            List<GetAllEventsQueryResponse> response= new();


            foreach (var eventt in events)
            {
                response.Add(new GetAllEventsQueryResponse
                {
                    EventName = eventt.EventName,
                    Description = eventt.Description,
                    Location = eventt.Location,
                    UserLimit = eventt.UserLimit,
                    StartDate = eventt.StartDate,
                    EndDate = eventt.EndDate
                });
            }
            return response;
           
            
            
        }
    }
}
