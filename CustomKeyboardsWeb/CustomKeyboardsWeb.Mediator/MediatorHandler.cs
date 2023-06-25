using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using CustomKeyboardsWeb.Mediator.Cummon.Interfaces;
using MediatR;

namespace CustomKeyboardsWeb.Mediator
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

    }
}