using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomKeyboardsWeb.Infrastructure.Data
{
    public class ApplicationMySqlDbContext : DbContext, IApplicationDbContext
    {
        private IConfiguration _configuration { get; set; }


        public ApplicationMySqlDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
                      ServerVersion.AutoDetect(_configuration.GetConnectionString("DefaultConnection")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationMySqlDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Key> Key { get; set; }
        public DbSet<Keyboard> Keyboard { get; set; }
        public DbSet<PuchaseHistory> PuchaseHistory { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Switch> Switch { get; set; }

        public async Task<int> Save()
        {
            return await SaveChangesAsync();
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }
    }
}
