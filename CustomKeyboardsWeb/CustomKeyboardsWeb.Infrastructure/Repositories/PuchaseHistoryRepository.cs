using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Domain.Entity;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;
using CustomKeyboardsWeb.Infrastructure.Repository;

namespace CustomKeyboardsWeb.Infrastructure.Repositories
{
    public class PuchaseHistoryRepository : Repository<PuchaseHistory>, IPuchaseHistoryRepository
    {
        public PuchaseHistoryRepository(IApplicationDbContext context) : base(context) { }
    }
}
