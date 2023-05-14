using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.UpdateKeyboard;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Infrastructure.Mappings;

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

            var keyboard = Keyboard.Create(
                Name.Create(model.Name),
                model.IdSwitch,
                model.IdKey,
                Price.Create(model.Price),
                model.Active);
            
            await _keyboardRepository.Create(keyboard);
            var keyboardDtoMap = _mapper.Map<KeyboardDto>(keyboard);
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
            var currentKeyboard = await _keyboardRepository.FindById(id);
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