using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Application.Features.Events.Command.UpdateCommand
{
    public class UpdateEventCommandValidator:AbstractValidator<UpdateEventCommandRequest>

    {
        public UpdateEventCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Event Id boş ola bilməz.")
                .NotEqual(Guid.Empty).WithMessage("Event Id düzgün olmalıdır.");

            RuleFor(x => x.EventName)
             .NotEmpty()
             .WithName("Adı");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Açıqlama");

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .GreaterThan(DateTime.Now).WithMessage("Başlama tarixi indiki vaxtdan sonra olmalıdır.")
                .WithName("Başlama tarixi");

            RuleFor(x => x.EndDate)
                 .NotEmpty()
                 .GreaterThan(x => x.StartDate).WithMessage("Bitmə tarixi başlanğıc tarixdən sonra olmalıdır.")
                 .WithName("Bitmə tarixi");


            RuleFor(x => x.Location)
               .NotEmpty().WithMessage("Məkan boş ola bilməz.")
               .MaximumLength(200).WithMessage("Məkan maksimum 200 simvol ola bilər.")
                 .WithName("Məkan");

            RuleFor(x => x.UserLimit)
                .GreaterThan(0).WithMessage("İştirakçı limiti 0-dan böyük olmalıdır.")
                .LessThanOrEqualTo(1000).WithMessage("İştirakçı limiti maksimum 1000 ola bilər.")
                .WithName("Istifadeci Sayi");

        }
    }
}
