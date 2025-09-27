using EventRegistration.Application.Interfaces.Repositories;
using EventRegistration.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace EventRegistration.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext context;

        public WriteRepository(DbContext context)
        {
            this.context = context;
        }

        private DbSet<T> Table { get => context.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);

        }
        public async Task<T> UpdateAsync(T entity) //Update asinxron heyata kecmir ona gore ozumuz yazacayiq asinxron islemesini
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(()=>Table.Remove(entity));
        }

      

        
    }
}
