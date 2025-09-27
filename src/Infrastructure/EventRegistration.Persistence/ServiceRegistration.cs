using EventRegistration.Application.Interfaces.Repositories;
using EventRegistration.Persistence.Context;
using EventRegistration.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventRegistration.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));//repolar generic oldugu ucun typeof istifade edirik
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        }
    }
}
