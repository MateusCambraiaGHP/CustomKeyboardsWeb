using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface ISwitchRepository
    {
        Task Create(Switch model);
        Task<Switch> Update(Switch model);
        Task<Switch> FindById(Guid id);
        Task<List<Switch>> GetAll();
    }
}
