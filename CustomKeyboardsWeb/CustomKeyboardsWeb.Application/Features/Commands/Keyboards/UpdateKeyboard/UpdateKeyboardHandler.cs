using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keyboards.UpdateKeyboard
{
    public class UpdateKeyboardHandler : IRequestHandler<UpdateKeyboardCommand, KeyboardDto>
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateKeyboardHandler(
            IKeyboardRepository keyboardRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _keyboardRepository = keyboardRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<KeyboardDto> Handle(UpdateKeyboardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var keyboardMap = _mapper.Map<Keyboard>(request);
                keyboardMap.CreatedAt = DateTime.UtcNow;
                keyboardMap.CreatedBy = "Administrator";
                await _keyboardRepository.Update(keyboardMap);
                await _unitOfWork.CommitChangesAsync();
                var keyboardDtoMap = _mapper.Map<KeyboardDto>(keyboardMap);
                return keyboardDtoMap;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
