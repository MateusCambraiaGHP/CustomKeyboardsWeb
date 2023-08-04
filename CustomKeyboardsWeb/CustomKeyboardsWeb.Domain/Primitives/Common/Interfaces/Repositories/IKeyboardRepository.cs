using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface IKeyboardRepository
    {
        Task Create(Keyboard model);
        Task<Keyboard> Update(Keyboard model);
        Task<Keyboard> FindById(int id);
        Task<List<Keyboard>> GetAll();
    }
}
