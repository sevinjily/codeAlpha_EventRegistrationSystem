using EventRegistration.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EventRegistration.Mapper
{
    public static class ServiceRegistration
    {
        public static void AddCustomMapperRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();

        }
    }
}
