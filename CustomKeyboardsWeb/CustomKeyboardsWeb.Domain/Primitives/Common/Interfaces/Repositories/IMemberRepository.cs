using CustomKeyboardsWeb.Domain.Primitives.Entities;
using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface IMemberRepository
    {
        Task Create(Member model);
        Task<Member> Update(Member model);
        Task<List<Member>> GetAsync(
            Expression<Func<Member, bool>> filter,
            Func<IQueryable<Member>, IOrderedQueryable<Member>> orderBy,
            Expression<Func<Member, object>>[] includes);
    }
}
