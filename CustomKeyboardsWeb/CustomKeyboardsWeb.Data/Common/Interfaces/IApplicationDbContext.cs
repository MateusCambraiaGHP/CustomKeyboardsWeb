using CustomKeyboardsWeb.Core.DomainObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keys;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Members;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Suppliers;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Switchies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CustomKeyboardsWeb.Data.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Key> Key { get; set; }
        public DbSet<Keyboard> Keyboard { get; set; }
        public DbSet<PuchaseHistory> PuchaseHistory { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Switch> Switch { get; set; }
        public DbSet<Member> Member { get; set; }
        public DatabaseFacade Database { get;}
        public Task<int> Save();
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
    }
}
