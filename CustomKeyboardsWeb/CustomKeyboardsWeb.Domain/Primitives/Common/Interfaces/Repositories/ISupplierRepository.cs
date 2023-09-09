using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        Task Create(Supplier model);
        Task<Supplier> Update(Supplier model);
        Task<Supplier> FindById(Guid id);
        Task<List<Supplier>> GetAll();
    }
}
