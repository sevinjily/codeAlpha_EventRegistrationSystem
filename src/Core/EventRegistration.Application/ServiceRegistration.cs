using EventRegistration.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using EventRegistration.Application.Behaviors;
using EventRegistration.Application.Features.Events.Rules;
using EventRegistration.Application.Bases;

namespace EventRegistration.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly=Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(assembly));

            services.AddTransient<ExceptionMiddleware>();
            //services.AddTransient<EventRules>();
            services.AddRulesFromAssemblyContaining(assembly,typeof(BaseRules));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("az");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
            
        {
          var types=assembly.GetTypes().Where(t=>t.IsSubclassOf(type)&&type!=t).ToList();
            foreach (var item in types)
            {
                services.AddTransient(item);
            }

            return services;
        }
    }
}
