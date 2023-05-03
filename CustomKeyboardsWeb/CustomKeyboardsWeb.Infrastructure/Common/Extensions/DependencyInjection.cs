using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;
using CustomKeyboardsWeb.Infrastructure.Data;
using CustomKeyboardsWeb.Infrastructure.Repositories;
using CustomKeyboardsWeb.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<ISwitchService, SwitchService>();
            services.AddScoped<ISwitchRepository, SwitchRepository>();
            services.AddScoped<IPuchaseHistoryService, PuchaseHistoryService>();
            services.AddScoped<IPuchaseHistoryRepository, PuchaseHistoryRepository>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
