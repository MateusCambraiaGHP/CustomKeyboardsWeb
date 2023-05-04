using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;

namespace CustomKeyboardsWeb.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IApplicationDbContext context) : base(context) { }
    }
}
