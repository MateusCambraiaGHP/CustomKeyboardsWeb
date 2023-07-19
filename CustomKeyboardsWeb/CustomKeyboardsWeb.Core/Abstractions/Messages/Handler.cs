using AutoMapper;

namespace CustomKeyboardsWeb.Mediator.Abstractions.Messages
{
    public abstract class Handler<TCommand> : BaseHandler<TCommand, BaseHandlerResponse>
       where TCommand : BaseMessage<BaseHandlerResponse>
    {
        protected Handler(IMapper mapper)
            : base(mapper)
        {
        }
    }

    public abstract class Handler<TCommand, T> : BaseHandler<TCommand, T>
        where T : BaseHandlerResponse
        where TCommand : BaseMessage<T>
    {
        protected Handler(IMapper mapper)
            : base(mapper)
        {
        }
    }
}
