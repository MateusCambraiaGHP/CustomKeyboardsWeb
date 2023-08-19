using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomKeyboardsWeb.Data.Repositories
{
    public class KeyboardRepository : Repository<Keyboard>, IKeyboardRepository
    {
        private readonly IApplicationDbContext _context;

        public KeyboardRepository(IApplicationDbContext context) : base(context)
        {
            _context = context;
            context.Set<Keyboard>();
        }

        public override async Task<Keyboard> FindById(Guid id)
        {
            var currentKeyboard = await _dbSet
                .AsNoTracking()
                .Include(kb => kb.Switch)
                .Include(kb => kb.Key)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            return currentKeyboard;
        }

        public override async Task<List<Keyboard>> GetAll()
        {
            List<Keyboard> currentKeyboardList = await _dbSet
                .Include(kb => kb.Switch)
                .Include(kb => kb.Key)
                .ToListAsync();
            return currentKeyboardList;
        }
    }
}
