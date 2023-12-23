using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keys;

namespace CustomKeyboardsWeb.Data.Repositories
{
    public class KeyRepository : Repository<Key>, IKeyRepository
    {
        public KeyRepository(IApplicationDbContext context) : base(context) { }
    }
}
