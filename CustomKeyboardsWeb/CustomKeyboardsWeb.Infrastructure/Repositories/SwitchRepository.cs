using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Domain.Entity;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;
using CustomKeyboardsWeb.Infrastructure.Repository;

namespace CustomKeyboardsWeb.Infrastructure.Repositories
{
    public class SwitchRepository : Repository<Switch>, ISwitchRepository
    {
        public SwitchRepository(IApplicationDbContext context) : base(context) { }
    }
}
