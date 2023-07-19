using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Data.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UnitOfWork(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CommitChangesAsync() => await _applicationDbContext.Save();
    }
}
