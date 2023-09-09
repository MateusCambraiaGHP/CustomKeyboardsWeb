using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Data.Data;
using CustomKeyboardsWeb.Data.Repositories;
using CustomKeyboardsWeb.Data.Transaction;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CustomKeyboardsWeb.Data.Common.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationMySqlDbContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IKeyboardRepository, KeyboardRepository>();
            services.AddScoped<IKeyRepository, KeyRepository>();
            services.AddScoped<IPuchaseHistoryRepository, PuchaseHistoryRepository>();
            services.AddScoped<ISwitchRepository, SwitchRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            var mappingProfiles = assembly.GetTypes().Where(a => a.Name.Contains("MappingProfile"));
            foreach (var mappingProfile in mappingProfiles)
            {
                services.AddAutoMapper(mappingProfile);
            }
            return services;
        }

        public static void MigrateDatabase(this IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<IApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();
        }
    }
}
