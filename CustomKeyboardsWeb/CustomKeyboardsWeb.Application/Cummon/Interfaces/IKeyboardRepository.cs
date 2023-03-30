using CustomKeyboardsWeb.Domain.Entity;

namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface IKeyboardRepository
    {
        Task Create(Keyboard model);
        Task<Keyboard> Update(Keyboard model);
        Task<Keyboard> FindById(int id);
        Task<List<Keyboard>> GetAll();
    }
}
