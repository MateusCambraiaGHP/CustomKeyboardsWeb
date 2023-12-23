using AutoMapper;
using FluentValidation.Results;
using MediatR;

namespace CustomKeyboardsWeb.Core.Messages.CommonMessages
{
    public abstract class BaseHandler<TRequest, TResponse> : IDisposable, IRequestHandler<TRequest, TResponse>
        where TResponse : BaseHandlerResponse
        where TRequest : BaseMessage<TResponse>
    {
        protected IMapper _mapper;

        public BaseHandler(IMapper mapper) => _mapper = mapper;

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        public abstract List<ValidationFailure> Validate(TRequest request);

        protected virtual TResponse ResponseOnFailValidation(string message, List<ValidationFailure> validationResults)
        {
            var response = Activator.CreateInstance<TResponse>();
            response.Success = false;
            response.Message = message;
            response.ValidationErrors = new List<string>();

            validationResults.ForEach(vr =>
            {
                response.ValidationErrors.Add(vr.ErrorMessage);
            });

            return response;
        }

        public virtual void Dispose() => _mapper = null;
    }
}
