using CustomKeyboardsWeb.Domain.Primitives.Entities;
using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface IPuchaseHistoryRepository
    {
        Task Create(PuchaseHistory model);
        Task<PuchaseHistory> Update(PuchaseHistory model);
        Task<List<PuchaseHistory>> GetAsync(
            Expression<Func<PuchaseHistory, bool>> filter,
            Func<IQueryable<PuchaseHistory>, IOrderedQueryable<PuchaseHistory>> orderBy,
            params Expression<Func<PuchaseHistory, object>>[] includes);
    }
}
