using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface IKeyboardRepository
    {
        Task Create(Keyboard model);
        Task<Keyboard> Update(Keyboard model);
        Task<Keyboard> FindById(Guid id);
        Task<List<Keyboard>> GetAll();
    }
}
