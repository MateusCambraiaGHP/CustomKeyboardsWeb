using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface IMemberRepository
    {
        Task Create(Member model);
        Task<Member> Update(Member model);
        Task<Member> FindById(Guid id);
        Task<List<Member>> GetAll();
    }
}
