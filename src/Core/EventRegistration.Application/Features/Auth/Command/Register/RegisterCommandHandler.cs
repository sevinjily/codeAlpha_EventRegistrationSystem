using EventRegistration.Application.Bases;
using EventRegistration.Application.Interfaces.AutoMapper;
using EventRegistration.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EventRegistration.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        public RegisterCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor):base(mapper,unitOfWork,httpContextAccessor)
        {
            
        }
        public Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
