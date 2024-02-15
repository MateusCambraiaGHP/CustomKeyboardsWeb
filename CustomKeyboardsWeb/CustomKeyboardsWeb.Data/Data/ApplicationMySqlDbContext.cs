using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using CustomKeyboardsWeb.Core.DomainObjects;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Customers;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keys;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Members;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Suppliers;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Switchies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace CustomKeyboardsWeb.Data.Data
{
    public class ApplicationMySqlDbContext : DbContext, IApplicationDbContext
    {
        private IConfiguration _configuration { get; set; }
        private readonly IMediatorHandler _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationMySqlDbContext(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            IMediatorHandler mediator)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
                      ServerVersion.AutoDetect(_configuration.GetConnectionString("DefaultConnection")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationMySqlDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Key> Key { get; set; }
        public DbSet<Keyboard> Keyboard { get; set; }
        public DbSet<PuchaseHistory> PuchaseHistory { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Switch> Switch { get; set; }
        public DbSet<Member> Member { get; set; }
        public override DatabaseFacade Database => base.Database;

        public async Task<int> Save()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is EntityBase &&
                    (e.State == EntityState.Added ||
                     e.State == EntityState.Modified));
            var httpContext = _httpContextAccessor.HttpContext;
            string token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var currentMember = await Member.SingleOrDefaultAsync(mb => mb.Token == token);
            foreach (var entry in entries)
            {
                var entity = ((EntityBase)entry.Entity);
                entity.SetLastModification(DateTime.Now, currentMember?.Email.Value);

                switch (entry.State)
                {
                    case EntityState.Detached:
                    case EntityState.Modified:
                        entry.Property(nameof(entity.InsertionDate)).IsModified = false;
                        entry.Property(nameof(entity.InsertionBy)).IsModified = false;
                        break;
                    case EntityState.Added:
                        entity.SetInsertionDate(DateTime.Now, currentMember?.Email.Value);
                        break;
                }
            }

            var success = await SaveChangesAsync();
            if (success > 0) PublishEvents();

            return success;
        }

        private void PublishEvents()
        {
            var domainEntities = ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.EventNotifications != null && x.Entity.EventNotifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.EventNotifications)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearEvents());

            var tasks = domainEvents
            .Select(async (domainEvent) =>
            {
                await _mediator.PublishEvent(domainEvent);
            });

            Task.WhenAll(tasks).Wait();
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity => base.Set<TEntity>();
    }
}
