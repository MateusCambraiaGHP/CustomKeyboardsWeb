using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keyboards.GetKeyboardList
{
    public class GetKeyBoardListHandle : IRequestHandler<GetKeyboardListQuery, List<KeyboardDto>>
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;

        public GetKeyBoardListHandle(
            IKeyboardRepository keyboardRepository,
            IMapper mapper)
        {
            _keyboardRepository = keyboardRepository;
            _mapper = mapper;
        }

        public async Task<List<KeyboardDto>> Handle(GetKeyboardListQuery request, CancellationToken cancellationToken)
        {
            var listKeyboard = await _keyboardRepository.GetAll();
            var listKeyboardMap = _mapper.Map<List<KeyboardDto>>(listKeyboard);
            foreach (var keyboard in listKeyboardMap)
            {
                keyboard.Price += keyboard.Switch.Price.Value + keyboard.Key.Price.Value;
            }
            return listKeyboardMap;
        }
    }
}
