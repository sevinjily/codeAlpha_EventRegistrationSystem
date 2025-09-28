using MediatR;

namespace EventRegistration.Application.Features.Events.Command.CreateCommand
{
    public class CreateEventCommandRequest:IRequest
    {
        public string EventName { get; set; } 
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int UserLimit { get; set; }
    }
}
