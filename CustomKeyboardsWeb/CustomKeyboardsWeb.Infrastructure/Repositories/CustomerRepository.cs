using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;

namespace CustomKeyboardsWeb.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IApplicationDbContext context) : base(context) { }
    }
}
