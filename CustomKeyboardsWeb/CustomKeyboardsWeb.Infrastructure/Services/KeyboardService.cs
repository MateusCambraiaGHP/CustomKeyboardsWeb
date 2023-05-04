using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.UpdateKeyboard;
using CustomKeyboardsWeb.Domain.Primitives;

namespace CustomKeyboardsWeb.Infrastructure.Services
{
    public class KeyboardService : IKeyboardService
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;

        public KeyboardService(
            IKeyboardRepository keyboardRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _keyboardRepository = keyboardRepository;
        }

        public async Task<KeyboardDto> Save(CreateKeyboardDto model)
        {
            var keyboardMap = _mapper.Map<Keyboard>(model);
            keyboardMap.CreatedAt = DateTime.UtcNow;
            keyboardMap.CreatedBy = "Administrator";
            await _keyboardRepository.Create(keyboardMap);
            var keyboardDtoMap = _mapper.Map<KeyboardDto>(model);
            return keyboardDtoMap;
        }

        public async Task<KeyboardDto> Edit(UpdateKeyboardDto model)
        {
            var keyboardMap = _mapper.Map<Keyboard>(model);
            keyboardMap.CreatedAt = DateTime.UtcNow;
            keyboardMap.CreatedBy = "Administrator";
            await _keyboardRepository.Update(keyboardMap);
            var keyboardDtoMap = _mapper.Map<KeyboardDto>(model);
            return keyboardDtoMap;
        }

        public async Task<KeyboardDto> FindByIdAsync(int id)
        {
            var currentKeyboard = await _keyboardRepository.FindById(id) ?? new Keyboard();
            var keyboardMap = _mapper.Map<KeyboardDto>(currentKeyboard);
            return keyboardMap;
        }

        public async Task<List<KeyboardDto>> GetAll()
        {
            var listKeyboard = await _keyboardRepository.GetAll() ?? new List<Keyboard>();
            var listKeyboardMap = _mapper.Map<List<KeyboardDto>>(listKeyboard);
            return listKeyboardMap;
        }
    }
}