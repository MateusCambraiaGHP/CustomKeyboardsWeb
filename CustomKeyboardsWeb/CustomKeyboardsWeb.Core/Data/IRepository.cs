using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Core.Data
{
    public interface IRepository<TEntity>
    {
        Task Create(TEntity entityModel);
        Task<TEntity> Update(TEntity entityModel);
        Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            params Expression<Func<TEntity, object>>[] includes);
    }
}
