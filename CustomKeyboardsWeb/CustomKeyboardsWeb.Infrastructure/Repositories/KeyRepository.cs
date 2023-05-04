using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;

namespace CustomKeyboardsWeb.Infrastructure.Repositories
{
    public class KeyRepository : Repository<Key>, IKeyRepository
    {
        public KeyRepository(IApplicationDbContext context) : base(context) { }
    }
}
