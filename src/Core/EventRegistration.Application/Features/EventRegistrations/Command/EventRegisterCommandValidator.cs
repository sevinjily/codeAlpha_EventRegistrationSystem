using FluentValidation;

namespace EventRegistration.Application.Features.EventRegistrations.Command
{
    public class EventRegisterCommandValidator:AbstractValidator<CreateEventRegistrationCommandRequest>
    {
        public EventRegisterCommandValidator()
        {
            RuleFor(x => x.EventId)
                .NotEmpty().WithMessage("Event Id cannot be empty.")
                  .NotEqual(Guid.Empty).WithMessage("Event Id must be correct."); ;
        }
    }
}
