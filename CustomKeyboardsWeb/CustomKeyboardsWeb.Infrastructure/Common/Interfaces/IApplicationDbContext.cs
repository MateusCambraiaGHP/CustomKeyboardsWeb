using CustomKeyboardsWeb.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomKeyboardsWeb.Infrastructure.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Key> Key { get; set; }
        public DbSet<Keyboard> Keyboard { get; set; }
        public DbSet<PuchaseHistory> PuchaseHistory { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Switch> Switch { get; set; }
        public Task<int> Save();
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
    }
}
