using CustomKeyboardsWeb.Application.Cummon.Abstractions;
using CustomKeyboardsWeb.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CustomKeyboardsWeb.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
            return services;
        }
    }
}
