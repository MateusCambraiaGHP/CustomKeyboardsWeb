namespace CustomKeyboardsWeb.Core.Messages.CommonMessages
{
    public abstract class Command<TResponse> : BaseMessage<TResponse>
    {
    }
    public abstract class Command : BaseMessage<BaseHandlerResponse>
    {
    }
}
