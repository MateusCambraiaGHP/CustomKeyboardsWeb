using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;
using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface IKeyboardRepository
    {
        Task Create(Keyboard model);
        Task<Keyboard> Update(Keyboard model);
        Task<List<Keyboard>> GetAsync(
            Expression<Func<Keyboard, bool>> filter,
            Func<IQueryable<Keyboard>, IOrderedQueryable<Keyboard>> orderBy,
            params Expression<Func<Keyboard, object>>[] includes);
    }
}
