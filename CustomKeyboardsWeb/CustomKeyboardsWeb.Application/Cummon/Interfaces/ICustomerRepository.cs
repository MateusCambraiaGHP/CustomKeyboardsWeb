using CustomKeyboardsWeb.Domain.Entity;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface ICustomerRepository
    {
        Task Create(Customer model);
        Task<Customer> Update(Customer model);
        Task<Customer> FindById(int id);
        Task<List<Customer>> GetAll();
    }
}
