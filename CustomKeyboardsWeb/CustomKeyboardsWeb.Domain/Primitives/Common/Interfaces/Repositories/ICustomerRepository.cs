using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;
using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task Create(Customer model);
        Task<Customer> Update(Customer model);
        Task<List<Customer>> GetAsync(
            Expression<Func<Customer, bool>> filter,
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy,
            params Expression<Func<Customer, object>>[] includes);
    }
}
