using EventRegistration.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using EventRegistration.Application.Behaviors;

namespace EventRegistration.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly=Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(assembly));

            services.AddTransient<ExceptionMiddleware>();

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("az");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }
    }
}
