using CustomKeyboardsWeb.Domain.Primitives.Entities.Suppliers;
using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        Task Create(Supplier model);
        Task<Supplier> Update(Supplier model);
        Task<List<Supplier>> GetAsync(
            Expression<Func<Supplier, bool>> filter,
            Func<IQueryable<Supplier>, IOrderedQueryable<Supplier>> orderBy,
            params Expression<Func<Supplier, object>>[] includes);
    }
}
