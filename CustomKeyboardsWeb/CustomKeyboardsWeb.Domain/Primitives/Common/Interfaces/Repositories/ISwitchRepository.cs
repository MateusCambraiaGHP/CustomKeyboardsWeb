using CustomKeyboardsWeb.Domain.Primitives.Entities;
using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface ISwitchRepository
    {
        Task Create(Switch model);
        Task<Switch> Update(Switch model);
        Task<List<Switch>> GetAsync(
            Expression<Func<Switch, bool>> filter,
            Func<IQueryable<Switch>, IOrderedQueryable<Switch>> orderBy,
            params Expression<Func<Switch, object>>[] includes);
    }
}
