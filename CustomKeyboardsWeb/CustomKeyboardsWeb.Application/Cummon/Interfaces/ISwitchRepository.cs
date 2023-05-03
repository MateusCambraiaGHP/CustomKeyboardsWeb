
using CustomKeyboardsWeb.Domain.Primitives;
namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface ISwitchRepository
    {
        Task Create(Switch model);
        Task<Switch> Update(Switch model);
        Task<Switch> FindById(int id);
        Task<List<Switch>> GetAll();
    }
}
