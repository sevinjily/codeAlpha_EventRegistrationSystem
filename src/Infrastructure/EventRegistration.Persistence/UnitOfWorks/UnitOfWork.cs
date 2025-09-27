using EventRegistration.Application.Interfaces.Repositories;
using EventRegistration.Application.Interfaces.UnitOfWorks;
using EventRegistration.Persistence.Context;
using EventRegistration.Persistence.Repositories;

namespace EventRegistration.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async ValueTask DisposeAsync() => await context.DisposeAsync();
        public int Save() => context.SaveChanges();
        public async Task<int> SaveAsync() => await context.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(context);
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(context);
       
    }
}
