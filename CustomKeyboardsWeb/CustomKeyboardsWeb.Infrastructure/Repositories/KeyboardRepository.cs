using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;

namespace CustomKeyboardsWeb.Infrastructure.Repositories
{
    public class KeyboardRepository : Repository<Keyboard>, IKeyboardRepository
    {
        public KeyboardRepository(IApplicationDbContext context) : base(context) { }
    }
}
