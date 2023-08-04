using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface IKeyRepository
    {
        Task Create(Key model);
        Task<Key> Update(Key model);
        Task<Key> FindById(int id);
        Task<List<Key>> GetAll();
    }
}
