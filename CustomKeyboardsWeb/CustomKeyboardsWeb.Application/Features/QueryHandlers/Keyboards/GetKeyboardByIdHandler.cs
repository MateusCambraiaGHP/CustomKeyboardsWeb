using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;
using FluentValidation.Results;
using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Keyboards
{
    public class GetKeyboardByIdHandler : Handler<GetKeyboardByIdQuery, GetKeyboardByIdQueryResponse>
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;

        public GetKeyboardByIdHandler(
            IKeyboardRepository keyboardRepository,
            IMapper mapper)
            : base(mapper)
        {
            _keyboardRepository = keyboardRepository;
            _mapper = mapper;
        }

        public override async Task<GetKeyboardByIdQueryResponse> Handle(GetKeyboardByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new Expression<Func<Keyboard, object>>[] { kb => kb.Key, kb => kb.Switch };

                var currentKeyboard = await _keyboardRepository.GetAsync(
                    kb => kb.Id == request.IdKeyboard, 
                    null, 
                    includes);
                var keyboardMap = _mapper.Map<KeyboardViewModel>(currentKeyboard);

                return new GetKeyboardByIdQueryResponse(keyboardMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(GetKeyboardByIdQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
