using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Data.Common.Interfaces;

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
