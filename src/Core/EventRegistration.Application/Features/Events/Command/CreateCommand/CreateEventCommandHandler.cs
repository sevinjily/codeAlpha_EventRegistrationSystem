using EventRegistration.Application.Interfaces.AutoMapper;
using EventRegistration.Application.Interfaces.UnitOfWorks;
using EventRegistration.Application.Wrappers.ServiceResponses;
using EventRegistration.Domain.Entities;
using MediatR;

namespace EventRegistration.Application.Features.Events.Command.CreateCommand
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateEventCommandRequest request, CancellationToken cancellationToken)
        {
            Event eventt = new(request.EventName, request.Description, request.StartDate, request.EndDate, request.Location, request.UserLimit);
            await unitOfWork.GetWriteRepository<Event>().AddAsync(eventt);
            await unitOfWork.SaveAsync();
            //return new ServiceResponse(true,System.Net.HttpStatusCode.Created,"Ugurla yaradildi!");

            return Unit.Value;
        }
    }
}
