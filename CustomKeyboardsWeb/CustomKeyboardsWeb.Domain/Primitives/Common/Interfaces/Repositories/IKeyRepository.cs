using CustomKeyboardsWeb.Domain.Primitives.Entities.Keys;
using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface IKeyRepository
    {
        Task Create(Key model);
        Task<Key> Update(Key model);
        Task<List<Key>> GetAsync(
            Expression<Func<Key, bool>> filter,
            Func<IQueryable<Key>, IOrderedQueryable<Key>> orderBy,
            params Expression<Func<Key, object>>[] includes);
    }
}
