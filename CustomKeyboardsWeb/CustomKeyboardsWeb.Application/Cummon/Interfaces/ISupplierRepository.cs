using CustomKeyboardsWeb.Domain.Primitives;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface ISupplierRepository
    {
        Task Create(Supplier model);
        Task<Supplier> Update(Supplier model);
        Task<Supplier> FindById(int id);
        Task<List<Supplier>> GetAll();
    }
}
