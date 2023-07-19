﻿using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using CustomKeyboardsWeb.Mediator.Cummon.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomKeyboardsWeb.Data.Data
{
    public class ApplicationMySqlDbContext : DbContext, IApplicationDbContext
    {
        private IConfiguration _configuration { get; set; }
        private readonly IMediatorHandler _mediator;


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
            var success = await SaveChangesAsync();
            if (success > 0) PublishEvents();

            return success;
        }

        private void PublishEvents()
        {
            //var domainEntities = ChangeTracker
            //    .Entries<Entity>()
            //    .Where(x => x.Entity.EventNotifications != null && x.Entity.EventNotifications.Any());

            //var domainEvents = domainEntities
            //    .SelectMany(x => x.Entity.EventNotifications)
            //    .ToList();

            //domainEntities.ToList()
            //    .ForEach(entity => entity.Entity.ClearEvents());

            //var tasks = domainEvents
            //.Select(async (domainEvent) =>
            //{
            //    await _mediator.PublishEvent(domainEvent);
            //});

            //Task.WhenAll(tasks).Wait();

        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity => base.Set<TEntity>();
    }
}