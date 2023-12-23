using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Switchies;

namespace CustomKeyboardsWeb.Data.Repositories
{
    public class SwitchRepository : Repository<Switch>, ISwitchRepository
    {
        public SwitchRepository(IApplicationDbContext context) : base(context) { }
    }
}
