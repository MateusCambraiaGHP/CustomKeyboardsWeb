using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Data.Repositories
{
    public class PuchaseHistoryRepository : Repository<PuchaseHistory>, IPuchaseHistoryRepository
    {
        public PuchaseHistoryRepository(IApplicationDbContext context) : base(context) { }
    }
}
