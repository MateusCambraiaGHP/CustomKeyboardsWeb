using AutoMapper;
using FluentValidation.Results;
using MediatR;

namespace CustomKeyboardsWeb.Core.Messages
{
    public abstract class BaseHandler<TRequest, TResponse> : IDisposable, IRequestHandler<TRequest, TResponse>
        where TResponse : BaseHandlerResponse
        where TRequest : BaseMessage<TResponse>
    {
        protected IMapper _mapper;

        public BaseHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        public abstract List<ValidationFailure> Validate(TRequest request);

        protected virtual TResponse ResponseOnFailValidation(string message, List<ValidationFailure> validationResults)
        {
            var response = Activator.CreateInstance<TResponse>();
            response.Success = false;
            validationResults.ForEach(e =>
            {
                message += $"{e.ErrorMessage}, ";
            });

            response.Message = message;

            return response;
        }

        public virtual void Dispose()
        {
            _mapper = null;
        }
    }
}
