using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;

namespace CustomKeyboardsWeb.Infrastructure.Repositories
{
    public class SwitchRepository : Repository<Switch>, ISwitchRepository
    {
        public SwitchRepository(IApplicationDbContext context) : base(context) { }
    }
}
