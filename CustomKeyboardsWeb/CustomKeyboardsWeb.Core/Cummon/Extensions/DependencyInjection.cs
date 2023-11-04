using CustomKeyboardsWeb.Core.Communication.Mediator;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using CustomKeyboardsWeb.Core.Messages.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CustomKeyboardsWeb.Core.Cummon.Extensions
{
    public static class MediatorIoc
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            return services;
        }
    }
}
