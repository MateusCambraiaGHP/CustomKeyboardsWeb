using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Data.Repositories
{
    public class KeyRepository : Repository<Key>, IKeyRepository
    {
        public KeyRepository(IApplicationDbContext context) : base(context) { }
    }
}
