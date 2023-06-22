using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Data.Repositories
{
    public class SwitchRepository : Repository<Switch>, ISwitchRepository
    {
        public SwitchRepository(IApplicationDbContext context) : base(context) { }
    }
}
