using EventRegistration.Application.Interfaces.AutoMapper;
using EventRegistration.Mapper.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
