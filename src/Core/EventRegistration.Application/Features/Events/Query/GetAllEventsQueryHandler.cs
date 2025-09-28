using EventRegistration.Application.Interfaces.UnitOfWorks;
using EventRegistration.Application.Wrappers.ServiceResponses;
using EventRegistration.Domain.Entities;
using MediatR;

namespace EventRegistration.Application.Features.Events.Query
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQueryRequest, ServiceResponseWithData<IList<GetAllEventsQueryResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponseWithData<IList<GetAllEventsQueryResponse>>> Handle(GetAllEventsQueryRequest request, CancellationToken cancellationToken)
        {
            var events = await unitOfWork.GetReadRepository<Event>().GetAllAsync();
            List <GetAllEventsQueryResponse> response= new();


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
            return new ServiceResponseWithData<IList<GetAllEventsQueryResponse>>
            (
               value: response,
               isSuccess: true,
               statusCode: System.Net.HttpStatusCode.OK
             );
            
            
            
        }
    }
}
