﻿using EventRegistration.Application.Interfaces.Repositories;
using EventRegistration.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace EventRegistration.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class,IEntityBase,new()
    {
        private readonly DbContext context;

        public ReadRepository(DbContext context)
        {
            this.context = context;
        }

        private DbSet<T> Table { get=>context.Set<T>(); }//her metodun icinde context.Set<T>(); yazmayim deye qisa formada edirik

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
           IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();//ef prosesi izlemesin.Onsuz sadece get islemi apaririq.Her hansi bir deyisiklik etmirik.Bize lazim olan esas datanin gelmeyidir
            if (include is not null) queryable = include(queryable);
            if(predicate is not null) queryable=queryable.Where(predicate);
            if (orderBy is not null) 
                return await orderBy(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();//ef prosesi izlemesin.Onsuz sadece get islemi apaririq.Her hansi bir deyisiklik etmirik.Bize lazim olan esas datanin gelmeyidir
            if (include is not null) queryable = include(queryable);
              //queryable.Where(predicate);

            return await queryable.FirstOrDefaultAsync(predicate);

        }


        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null) Table.Where(predicate);
            return await Table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if (!enableTracking) Table.AsNoTracking();
            return Table.Where(predicate);
        }
    }
}
