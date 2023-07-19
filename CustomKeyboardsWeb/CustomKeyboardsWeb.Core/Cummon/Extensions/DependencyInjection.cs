using CustomKeyboardsWeb.Mediator.Cummon.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CustomKeyboardsWeb.Mediator.Cummon.Extensions
{
    public static class MediatorIoc
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            return services;
        }
    }
}
