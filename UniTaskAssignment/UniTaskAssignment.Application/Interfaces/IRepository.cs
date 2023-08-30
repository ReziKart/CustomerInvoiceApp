using System;
using System.Linq.Expressions;

namespace UniTaskAssignment.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task RemoveAsync(TEntity aggregate);

        Task<TEntity> UpdateAsync(TEntity aggregate);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null);

        IUnitOfWork UnitOfWork { get; }

    }


}

