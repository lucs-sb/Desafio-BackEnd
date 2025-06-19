using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MotoHub.Domain.Interfaces.Repositories.Base;
using MotoHub.Domain.Repository;
using System.Linq.Expressions;

namespace MotoHub.Infrastructure.Repositories.Base;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _dbContext;

    public Repository(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<TEntity?> GetByIdAsync(object id) => await _dbContext.Set<TEntity>().FindAsync(id).AsTask();

    public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity).AsTask();

    public async Task ExecuteUpdateAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setProperties)
    {
        var query = _dbContext.Set<TEntity>().Where(filter);
        await query.ExecuteUpdateAsync(setProperties);
    }

    public async Task ExecuteDeleteAsync(Expression<Func<TEntity, bool>> filter)
    {
        var query = _dbContext.Set<TEntity>().Where(filter);
        await query.ExecuteDeleteAsync();
    }
}
