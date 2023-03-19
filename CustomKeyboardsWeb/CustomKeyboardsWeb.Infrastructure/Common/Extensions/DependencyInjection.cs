using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;
using CustomKeyboardsWeb.Infrastructure.Data;
using CustomKeyboardsWeb.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MyHardwareWeb.Infrastructure.Services;

namespace CustomKeyboardsWeb.Infrastructure.Common.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationMySqlDbContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
