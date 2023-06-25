namespace CustomKeyboardsWeb.Mediator.Abstractions.Messages
{
    public abstract class Command<TResponse> : BaseMessage<TResponse>
    {
    }
    public abstract class Command : BaseMessage<BaseHandlerResponse>
    {
    }
}
