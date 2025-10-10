using EventRegistration.Application.Bases;
using EventRegistration.Application.Features.EventRegistrations.Rules;
using EventRegistration.Application.Features.Events.Command.CreateCommand;
using EventRegistration.Application.Interfaces.AutoMapper;
using EventRegistration.Application.Interfaces.UnitOfWorks;
using EventRegistration.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventRegistration.Application.Features.EventRegistrations.Command
{
    public class CreateEventRegistrationCommandHandler :BaseHandler, IRequestHandler<CreateEventRegistrationCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly RegistrationRules registrationRules;

        public CreateEventRegistrationCommandHandler(UserManager<User> userManager,RegistrationRules registrationRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.registrationRules = registrationRules;
        }

        public async Task<Unit> Handle(CreateEventRegistrationCommandRequest request, CancellationToken cancellationToken)
        {
            Event findEvent =await unitOfWork.GetReadRepository<Event>().GetAsync(x=>x.Id==request.EventId);
            await registrationRules.EventMustExist(findEvent);

            string? findUser = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userId=Guid.Parse(findUser);

            await registrationRules.UserMustBeAuthenticated(findUser);

            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            await registrationRules.UserMustBeExist(user);

            int userAge = DateTime.UtcNow.Year - user.BirthDate.Year;
           await registrationRules.UserAgeMustBeGreaterThan11(userAge);


            Registration existingRegistration = await unitOfWork.GetReadRepository<Registration>()
                                            .GetAsync(x => x.EventId == request.EventId && x.UserId == userId);

            await registrationRules.UserMustRegisterOneTime(existingRegistration);

            Registration registration = mapper.Map<Registration>(request);
            registration.UserId = userId;
            registration.EventId = request.EventId;

            await unitOfWork.GetWriteRepository<Registration>().AddAsync(registration);

            await unitOfWork.SaveAsync();

            return Unit.Value;

        }
    }
}
