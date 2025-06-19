using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace MotoHub.Domain.Interfaces.Repositories.Base;

public interface IRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(object id);
    Task ExecuteUpdateAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setProperties);
    Task ExecuteDeleteAsync(Expression<Func<TEntity, bool>> filter);
}