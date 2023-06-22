using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Queries.Keyboards.GetKeyboardById
{
    public class GetKeyboardByIdHandler : IRequestHandler<GetKeyboardByIdQuery, KeyboardDto>
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;

        public GetKeyboardByIdHandler(
            IKeyboardRepository keyboardRepository,
            IMapper mapper)
        {
            _keyboardRepository = keyboardRepository;
            _mapper = mapper;
        }

        public async Task<KeyboardDto> Handle(GetKeyboardByIdQuery request, CancellationToken cancellationToken)
        {
            var currentKeyboard = await _keyboardRepository.FindById(request.Id);
            var keyboardMap = _mapper.Map<KeyboardDto>(currentKeyboard);
            return keyboardMap;
        }
    }
}
