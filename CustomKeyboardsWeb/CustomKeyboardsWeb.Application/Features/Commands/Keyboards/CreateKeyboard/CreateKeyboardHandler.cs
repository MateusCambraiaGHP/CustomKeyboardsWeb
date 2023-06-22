using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keyboards.CreateKeyboard
{
    public class CreateKeyboardHandler : IRequestHandler<CreateKeyboardCommand, KeyboardDto>
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateKeyboardHandler(
            IKeyboardRepository keyboardRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _keyboardRepository = keyboardRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<KeyboardDto> Handle(CreateKeyboardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var keyboard = Keyboard.Create(
                    Name.Create(request.KeyboardDto.Name),
                    request.KeyboardDto.IdSwitch,
                    request.KeyboardDto.IdKey,
                    Price.Create(request.KeyboardDto.Price),
                    request.KeyboardDto.Active);
                await _keyboardRepository.Create(keyboard);
                await _unitOfWork.CommitChangesAsync();
                var keyboardDtoMap = _mapper.Map<KeyboardDto>(keyboard);
                return keyboardDtoMap;
            }
            catch (Exception)
            {
                var keyboardDtoMap = _mapper.Map<KeyboardDto>(request.KeyboardDto);
                return keyboardDtoMap;
            }
        }
    }
}
