using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomKeyboardsWeb.Data.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        private readonly IApplicationDbContext _context;

        public MemberRepository(IApplicationDbContext context) 
            : base(context) 
        {
            _context = context;
            context.Set<Member>();
        }

        public async Task<Member> FindByEmailAndPasswork(Member model)
        {
            var currentMember = await _context.Member
                .AsNoTracking()
                .FirstOrDefaultAsync(m =>
                    m.Email.Value == model.Email.Value &&
                    m.Password.Value == m.Password.Value);

            return currentMember;
        }
    }
}
