using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Core.Messages.Notifications;
using MediatR;

namespace CustomKeyboardsWeb.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> SendCommand<TResponse>(BaseMessage<TResponse> command)
            where TResponse : BaseHandlerResponse
        {
            return await _mediator.Send(command);
        }

        public async Task<BaseHandlerResponse> SendCommand<TCommand>(TCommand command)
            where TCommand : Command
        {
            return await _mediator.Send(command);
        }

        public async Task<TResponse> SendQuery<TResponse>(BaseMessage<TResponse> query)
            where TResponse : BaseHandlerResponse
        {
            return await _mediator.Send(query);
        }

        public async Task PublishNotification<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }

        public async Task PublishEvent<TEvent>(TEvent @event)
        {
            await _mediator.Publish(@event);
        }
    }
}