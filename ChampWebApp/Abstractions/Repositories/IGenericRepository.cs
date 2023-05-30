using System.Linq.Expressions;
using System.Xml.Linq;

namespace ChampWebApp.Abstractions.Repositories;

public interface IGenericRepository<TEntity> where TEntity:class
{
    public Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int? take = null, int? skip = null,
        string includeProperties = "");

    public Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> func, string? relatedData = null);

    public ValueTask<TEntity> CreateAsync(TEntity model);

    public Task<bool> DeleteAsync(TEntity entity);

    public ValueTask<TEntity> UpdateAsync(TEntity model);
}