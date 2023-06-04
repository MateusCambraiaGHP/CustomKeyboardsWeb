using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Infrastructure.Common.Extensions.MappingProfiles;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;
using CustomKeyboardsWeb.Infrastructure.Data;
using CustomKeyboardsWeb.Infrastructure.Repositories;
using CustomKeyboardsWeb.Infrastructure.Services;
using CustomKeyboardsWeb.Infrastructure.Transaction;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CustomKeyboardsWeb.Infrastructure.Common.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationMySqlDbContext>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IKeyboardService, KeyboardService>();
            services.AddScoped<IKeyboardRepository, KeyboardRepository>();
            services.AddScoped<IKeyService, KeyService>();
            services.AddScoped<IKeyRepository, KeyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISwitchService, SwitchService>();
            services.AddScoped<ISwitchRepository, SwitchRepository>();
            services.AddScoped<IPuchaseHistoryService, PuchaseHistoryService>();
            services.AddScoped<IPuchaseHistoryRepository, PuchaseHistoryRepository>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            var mappingProfiles = assembly.GetTypes().Where(a => a.Name.Contains("MappingProfile"));
            foreach (var mappingProfile in mappingProfiles)
            {
                services.AddAutoMapper(mappingProfile);
            }
            return services;
        }
    }
}
