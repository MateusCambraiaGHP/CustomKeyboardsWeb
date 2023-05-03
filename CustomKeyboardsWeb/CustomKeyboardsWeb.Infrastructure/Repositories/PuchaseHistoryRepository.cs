using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;

namespace CustomKeyboardsWeb.Infrastructure.Repositories
{
    public class PuchaseHistoryRepository : Repository<PuchaseHistory>, IPuchaseHistoryRepository
    {
        public PuchaseHistoryRepository(IApplicationDbContext context) : base(context) { }
    }
}
