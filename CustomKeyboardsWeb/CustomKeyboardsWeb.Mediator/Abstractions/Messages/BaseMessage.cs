using FluentValidation.Results;
using MediatR;

namespace CustomKeyboardsWeb.Mediator.Abstractions.Messages
{
    public abstract class BaseMessage<TResponse> : IRequest<TResponse>
    {
        public DateTime ExecTime { get; }
        public List<ValidationFailure> ValidationResult { get; set; }

        public BaseMessage()
        {
            ExecTime = DateTime.Now;
            ValidationResult = new List<ValidationFailure>();
        }

        public virtual bool IsValid()
        {
            return ValidationResult.Count == 0;
        }
    }
}
