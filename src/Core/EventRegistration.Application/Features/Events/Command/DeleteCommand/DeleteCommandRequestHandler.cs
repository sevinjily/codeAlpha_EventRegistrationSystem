using EventRegistration.Application.Interfaces.UnitOfWorks;
using EventRegistration.Application.Wrappers.ServiceResponses;
using EventRegistration.Domain.Entities;
using MediatR;

namespace EventRegistration.Application.Features.Events.Command.DeleteCommand
{
    public class DeleteCommandRequestHandler : IRequestHandler<DeleteCommandRequest, ServiceResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse> Handle(DeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var eventt = await unitOfWork.GetReadRepository<Event>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            eventt.IsDeleted=true;
            await unitOfWork.GetWriteRepository<Event>().UpdateAsync(eventt);
            await unitOfWork.SaveAsync();

            return new ServiceResponse(true, System.Net.HttpStatusCode.OK,"Deleted successfully!");
        }
    }
}
