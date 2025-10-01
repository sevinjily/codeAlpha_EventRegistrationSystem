using EventRegistration.Application.Interfaces.UnitOfWorks;
using EventRegistration.Application.Wrappers.ServiceResponses;
using EventRegistration.Domain.Entities;
using MediatR;

namespace EventRegistration.Application.Features.Events.Command.DeleteCommand
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteEventCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteEventCommandRequest request, CancellationToken cancellationToken)
        {
            var eventt = await unitOfWork.GetReadRepository<Event>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            eventt.IsDeleted=true;
            await unitOfWork.GetWriteRepository<Event>().UpdateAsync(eventt);
            await unitOfWork.SaveAsync();

            //return new ServiceResponse(true, System.Net.HttpStatusCode.OK,"Deleted successfully!");
            return Unit.Value;
        }
    }
}
