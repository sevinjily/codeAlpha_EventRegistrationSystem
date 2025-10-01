using FluentValidation;

namespace EventRegistration.Application.Features.Events.Command.CreateCommand
{
    public class CreateEventCommandValidator:AbstractValidator<CreateEventCommandRequest>
    {
        public CreateEventCommandValidator()
        {
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
