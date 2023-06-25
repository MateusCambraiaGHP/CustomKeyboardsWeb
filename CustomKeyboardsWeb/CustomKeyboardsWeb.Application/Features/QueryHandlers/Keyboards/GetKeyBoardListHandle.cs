using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Queries.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Keyboards
{
    public class GetKeyBoardListHandle : Handler<GetKeyboardListQuery, GetKeyboardListQueryResponse>
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;

        public GetKeyBoardListHandle(
            IKeyboardRepository keyboardRepository,
            IMapper mapper)
            :base(mapper)
        {
            _keyboardRepository = keyboardRepository;
            _mapper = mapper;
        }

        public override async Task<GetKeyboardListQueryResponse> Handle(GetKeyboardListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listKeyboard = await _keyboardRepository.GetAll();
                var listKeyboardMap = _mapper.Map<List<KeyboardViewModel>>(listKeyboard);
                foreach (var keyboard in listKeyboardMap)
                {
                    keyboard.Price += keyboard.Switch.Price.Value + keyboard.Key.Price.Value;
                }
                return new GetKeyboardListQueryResponse(listKeyboardMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task<List<ValidationFailure>> Validate(GetKeyboardListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
