using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UniTaskAssignment.Application.Interfaces;
using UniTaskAssignment.Persistence.Data;

namespace UniTaskAssignment.Persistence.Repositories
{
    public class SqlRepository<TEntity> : IRepository<TEntity>
     where TEntity : class
    {
        protected readonly InvoiceDbContext Context;

        public IUnitOfWork UnitOfWork => Context;
        public SqlRepository(InvoiceDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<TEntity> AddAsync(TEntity aggregate)
        {
            var res = await Context.Set<TEntity>().AddAsync(aggregate);

            return res.Entity;
        }

        public Task RemoveAsync(TEntity aggregate)
        {
            Context.Entry(aggregate).State = EntityState.Deleted;

            return Task.CompletedTask;
        }


        public Task<TEntity> UpdateAsync(TEntity aggregate)
        {
            Context.Set<TEntity>().Update(aggregate);

            return Task.FromResult(aggregate);
        }


        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            return predicate == null ?
                  Context.Set<TEntity>().ToListAsync()
                : Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

    }

}

