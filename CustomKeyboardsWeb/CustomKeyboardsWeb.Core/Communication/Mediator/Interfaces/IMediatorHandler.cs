using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces
{
    public interface IMediatorHandler
    {
        Task<BaseHandlerResponse> SendCommand<TCommand>(TCommand command) where TCommand : Command;
        Task<TResponse> SendCommand<TResponse>(BaseMessage<TResponse> command)
            where TResponse : BaseHandlerResponse;

        Task<TResponse> SendQuery<TResponse>(BaseMessage<TResponse> query)
            where TResponse : BaseHandlerResponse;

        Task PublishEvent<TEvent>(TEvent @event);
    }
}
