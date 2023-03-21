using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Domain.Entity;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;
using CustomKeyboardsWeb.Infrastructure.Repository;

namespace CustomKeyboardsWeb.Infrastructure.Repositories
{
    public class KeyboardRepository : Repository<Keyboard>, IKeyboardRepository
    {
        public KeyboardRepository(IApplicationDbContext context) : base(context) { }
    }
}
