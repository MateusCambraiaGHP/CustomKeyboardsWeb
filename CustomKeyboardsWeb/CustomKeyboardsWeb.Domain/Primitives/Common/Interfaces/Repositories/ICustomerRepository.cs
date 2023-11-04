using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task Create(Customer model);
        Task<Customer> Update(Customer model);
        Task<Customer> FindById(Guid id);
        Task<List<Customer>> GetAll();
    }
}
