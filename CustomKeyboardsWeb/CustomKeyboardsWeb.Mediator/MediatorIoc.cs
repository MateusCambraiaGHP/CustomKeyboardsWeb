using CustomKeyboardsWeb.Mediator.Abstractions.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CustomKeyboardsWeb.Mediator
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
