using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface IPuchaseHistoryRepository
    {
        Task Create(PuchaseHistory model);
        Task<PuchaseHistory> Update(PuchaseHistory model);
        Task<PuchaseHistory> FindById(Guid id);
        Task<List<PuchaseHistory>> GetAll();
    }
}
