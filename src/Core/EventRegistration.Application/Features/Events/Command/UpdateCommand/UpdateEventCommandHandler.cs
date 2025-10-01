using EventRegistration.Application.Interfaces.AutoMapper;
using EventRegistration.Application.Interfaces.UnitOfWorks;
using EventRegistration.Application.Wrappers.ServiceResponses;
using EventRegistration.Domain.Entities;
using MediatR;

namespace EventRegistration.Application.Features.Events.Command.UpdateCommand
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateEventCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateEventCommandRequest request, CancellationToken cancellationToken)
        {
            var eventt=await unitOfWork.GetReadRepository<Event>().GetAsync(x=>x.Id==request.Id && !x.IsDeleted);

            var map=mapper.Map<Event,UpdateEventCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Event>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;
            //return new ServiceResponse(true, System.Net.HttpStatusCode.OK, "Updated successfully!");

        }
    }
}
