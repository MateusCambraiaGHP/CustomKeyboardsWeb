using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;
using Microsoft.EntityFrameworkCore;

namespace CustomKeyboardsWeb.Data.Repositories
{
    public class KeyboardRepository : Repository<Keyboard>, IKeyboardRepository
    {
        public KeyboardRepository(IApplicationDbContext context) : base(context) { }
    }
}
