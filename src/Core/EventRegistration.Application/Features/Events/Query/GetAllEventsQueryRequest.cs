using MediatR;

namespace EventRegistration.Application.Features.Events.Query
{
    public class GetAllEventsQueryRequest:IRequest<IList<GetAllEventsQueryResponse>>
    {
    }
}
