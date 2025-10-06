using EventRegistration.Application.Bases;
using EventRegistration.Application.Interfaces.AutoMapper;
using EventRegistration.Application.Interfaces.UnitOfWorks;
using EventRegistration.Application.Wrappers.ServiceResponses;
using EventRegistration.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EventRegistration.Application.Features.Events.Command.DeleteCommand
{
    public class DeleteEventCommandHandler : BaseHandler,IRequestHandler<DeleteEventCommandRequest, Unit>
    {

        public DeleteEventCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
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
