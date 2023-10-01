using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CustomKeyboardsCalculator.Core.Common.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
