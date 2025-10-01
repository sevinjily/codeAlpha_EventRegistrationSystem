using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Application.Features.Events.Command.DeleteCommand
{
    public class DeleteEventCommandValidator:AbstractValidator<DeleteEventCommandRequest>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Event Id boş ola bilməz.")
               .NotEqual(Guid.Empty).WithMessage("Event Id düzgün olmalıdır.");
        }
    }
}
